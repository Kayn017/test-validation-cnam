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
}