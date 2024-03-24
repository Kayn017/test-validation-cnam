using MorpionApp.Controllers.Enums;
using MorpionApp.Controllers.Evaluators;
using MorpionApp.Controllers.Interfaces;
using MorpionApp.Models;
using MorpionApp.Models.Exceptions;
using MorpionApp.Models.Games.TicTacToe;

namespace MorpionApp.Controllers.Games;

public class TicTacToeGameController : GameController
{
    public TicTacToeGameController(TicTacToeBoard board, Player[] players) : base(board, players)
    {
        this.WinConditions = new IEvaluator[]
        {
            new HorizontalLineEvaluator(3),
            new VerticalLineEvaluator(3),
            new DiagonalLineEvaluator(3)
        };
    }

    public override int MinNbPlayers => 2;
    public override int MaxNbPlayers => 2;

    public override bool CheckWin()
    {
        if (this.WinConditions.Any(evaluator => evaluator.Evaluate(this.Board, this.CurrentPlayer)))
        {
            this.EventManager.notify(EventTypes.Win, "Victoire de " + this.CurrentPlayer.Name);
            return true;
        }

        return false;
    }

    public override void Play(Position position)
    {
        TicTacToeToken token = new(this.CurrentPlayer);

        if(!this.Board.putTokenInCase(position, token))
            throw new InvalidMoveException();
        
        this.EventManager.notify(EventTypes.Play);

        if(!this.CheckWin())
            this.NextPlayer();
    }
    
    public override void GameLoop()
    {
        while (!this.isEnded)
        {
            this.EventManager.notify(EventTypes.Play);
            this.EventManager.notify(EventTypes.UserInput);
        }
    }

    public override Position moveCursor(Position cursor, ConsoleKey key)
    {
        switch (key)
        {   
            case ConsoleKey.UpArrow:
                if (cursor.Y > 0)
                {
                    cursor.Y--;
                }
                break;
            case ConsoleKey.DownArrow:
                if (cursor.Y < this.Board.NbRow - 1)
                {
                    cursor.Y++;
                }
                break;
            case ConsoleKey.LeftArrow:
                if (cursor.X > 0)
                {
                    cursor.X--;
                }
                break;
            case ConsoleKey.RightArrow:
                if (cursor.X < this.Board.NbColumn - 1)
                {
                    cursor.X++;
                }
                break;
            case ConsoleKey.Enter:
                try
                {
                    this.Play(cursor);
                }
                catch (InvalidMoveException exception)
                {
                    System.Console.WriteLine("Invalid move");
                } 
                break;
        }

        return cursor;
    }
}