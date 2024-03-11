using MorpionApp.Controllers.Enums;
using MorpionApp.Controllers.Games;
using MorpionApp.Models;
using MorpionApp.Models.Games.TicTacToe;

namespace MorpionApp.Controllers.Factory;

public class GameControllerFactory
{   
    public static GameController CreateGameController(Game game, Player[] players)
    {
        GameController gameController;
        
        switch (game)
        {
            case Game.TicTacToe:
                TicTacToeBoard board = new TicTacToeBoard();
                gameController = new TicTacToeGameController(board, players);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return gameController;
    }
}