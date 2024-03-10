using MorpionApp.Controllers;
using MorpionApp.Controllers.Enums;
using MorpionApp.Controllers.Interfaces;
using MorpionApp.Models;
using MorpionApp.Models.Interfaces;
using MorpionApp.Views.Interfaces;

namespace MorpionApp.Views;

public class ConsoleGridGameView : IGridGameView, IEventListener
{
    public GameController Controller { get; set; }
    
    public ConsoleGridGameView(GameController controller)
    {
        this.Controller = controller;
        this.Controller.EventManager.addListener(EventTypes.Play, this);
        this.Controller.EventManager.addListener(EventTypes.Win, this);
    }
    
    public void DrawGrid()
    {
        Console.Write("\n   ");
        for (int col = 0; col < Controller.Board.columnCount; col++)
        {
            Console.Write((col + 1) + " ");
        }

        Console.Write("\n  ┌");
        for (int col = 0; col < (Controller.Board.columnCount * 2) - 1; col++)
        {
            if (col % 2 == 0)
            {
                Console.Write("─");
            }
            else
            {
                Console.Write("┬");
            }
        }
        Console.WriteLine("┐");

        for (int row = 0; row < Controller.Board.rowCount; row++)
        {
            Console.Write((row + 1) + " │");

            for (int col = 0; col < Controller.Board.columnCount; col++)
            {
                // Console.Write(grid.getElementAt(new Position(row, col)).getDisplayString());
                IToken? token = Controller.Board.getCase(new Position(row, col)).Token;
                if (token != null)
                {
                    Console.Write(token.Value);
                }
                else
                {
                    Console.Write(" ");
                }
                    
                if (col < Controller.Board.columnCount - 1)
                {
                    Console.Write("│");
                }
            }
            Console.WriteLine("│");
        }

        Console.Write("  └");
        for (int col = 0; col < (Controller.Board.columnCount * 2) - 1; col++)
        {
            if (col % 2 == 0)
            {
                Console.Write("─");
            }
            else
            {
                Console.Write("┴");
            }
        }
        Console.WriteLine("┘");
    }

    public void OnUpdate(EventTypes eventType, string message)
    {
        switch (eventType)
        {
            case EventTypes.Play:
                this.DrawGrid();
                break;
            case EventTypes.Win:
                Console.WriteLine(message);
                break;
        }
    }
}