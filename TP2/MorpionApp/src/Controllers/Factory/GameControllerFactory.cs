using MorpionApp.Controllers.Enums;
using MorpionApp.Controllers.Games;
using MorpionApp.Models;
using MorpionApp.Models.Games.ConnectFour;
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
                TicTacToeBoard ticTacToeBoard = new TicTacToeBoard();
                gameController = new TicTacToeGameController(ticTacToeBoard, players);
                break;
            case Game.ConnectFour:
                ConnectFourBoard connectFourBoard = new ConnectFourBoard();
                gameController = new ConnectFourGameController(connectFourBoard, players);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return gameController;
    }
}