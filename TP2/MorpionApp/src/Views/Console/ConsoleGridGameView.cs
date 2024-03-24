using MorpionApp.Controllers;
using MorpionApp.Controllers.Enums;
using MorpionApp.Controllers.Interfaces;
using MorpionApp.Models;
using MorpionApp.Models.Exceptions;
using MorpionApp.Models.Interfaces;
using MorpionApp.Views.Interfaces;

namespace MorpionApp.Views.Console;

public class ConsoleGridGameView : IGridGameView, IEventListener
{
    public Position Cursor { get; set; }
    public GameController Controller { get; set; }
    
    public ConsoleGridGameView(GameController controller)
    {
        this.Cursor = new Position(0, 0);
        this.Controller = controller;
        this.Controller.EventManager.addListener(EventTypes.Play, this);
        this.Controller.EventManager.addListener(EventTypes.Win, this);
        this.Controller.EventManager.addListener(EventTypes.UserInput, this);
    }
    
    public void DrawGrid()
    {
        System.Console.Clear();
        System.Console.Write("\n   ");
        for (int col = 0; col < Controller.Board.NbColumn; col++)
        {
            System.Console.Write((col + 1) + " ");
        }

        System.Console.Write("\n  ┌");
        for (int col = 0; col < (Controller.Board.NbColumn * 2) - 1; col++)
        {
            if (col % 2 == 0)
            {
                System.Console.Write("─");
            }
            else
            {
                System.Console.Write("┬");
            }
        }
        System.Console.WriteLine("┐");

        for (int row = 0; row < Controller.Board.NbRow; row++)
        {
            System.Console.Write((row + 1) + " │");

            for (int col = 0; col < Controller.Board.NbColumn; col++)
            {
                IToken? token = Controller.Board.getCase(new Position(col, row)).Token;
                if (token != null)
                {
                    System.Console.Write(token.Value);
                }
                else
                {
                    System.Console.Write(" ");
                }
                    
                if (col < Controller.Board.NbColumn - 1)
                {
                    System.Console.Write("│");
                }
            }
            System.Console.WriteLine("│");
        }

        System.Console.Write("  └");
        for (int col = 0; col < (Controller.Board.NbColumn * 2) - 1; col++)
        {
            if (col % 2 == 0)
            {
                System.Console.Write("─");
            }
            else
            {
                System.Console.Write("┴");
            }
        }
        System.Console.WriteLine("┘");
        
        System.Console.SetCursorPosition(this.Cursor.X * 2 + 3, this.Cursor.Y + 3);
    }

    public void ReadUserInput()
    {
        ConsoleKeyInfo input = System.Console.ReadKey(true);

        this.Controller.moveCursor(this.Cursor, input.Key);
    }

    public void OnUpdate(EventTypes eventType, string message)
    {
        switch (eventType)
        {
            case EventTypes.Play:
                this.DrawGrid();
                break;
            case EventTypes.UserInput:
                this.ReadUserInput();
                break;
            case EventTypes.Win:
                System.Console.Clear();
                System.Console.WriteLine(message);
                this.Controller.isEnded = true;
                break;
        }
    }
}