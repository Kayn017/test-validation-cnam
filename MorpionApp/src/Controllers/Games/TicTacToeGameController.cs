using MorpionApp.Controllers.Enums;
using MorpionApp.Controllers.Evaluators;
using MorpionApp.Controllers.Interfaces;
using MorpionApp.Models;
using MorpionApp.Models.Exceptions;
using MorpionApp.Models.Games.TicTacToe;

namespace MorpionApp.Controllers.Games;

public class TicTacToeGameController : GameController
{
    public TicTacToeGameController(TicTacToeBoard board, Player[] players): base(players)
    {
        this.Board = board;

        this.WinConditions = new IEvaluator[]
        {
            new HorizontalLineEvaluator(3),
            new VerticalLineEvaluator(3),
            new DiagonalLineEvaluator(3)
        };
    }

    public override bool CheckWin()
    {
        if (this.WinConditions.Any(evaluator => evaluator.Evaluate(this.Board, this.CurrentPlayer)))
        {
            this.EventManager.notify(EventTypes.Win);
            return true;
        }

        return false;
    }

    public override void Play(Position position)
    {
        TicTacToeToken token = new(this.CurrentPlayer);

        if (!this.Board.playable(position))
        {
            throw new InvalidMoveException();
        }

        this.Board.Grid[position.X, position.Y].Token = token;
        
        this.EventManager.notify(EventTypes.Play);
    }
}