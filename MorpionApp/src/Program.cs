using System.Runtime.CompilerServices;
using MorpionApp.Controllers.Games;
using MorpionApp.Models;
using MorpionApp.Models.Games.TicTacToe;
using MorpionApp.Views.Console;

namespace MorpionApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            HumanPlayer[] players = new HumanPlayer[2];
            
            players[0] = new HumanPlayer(1, "Player 1");
            players[1] = new HumanPlayer(2, "Player 2");
            
            TicTacToeBoard ticTacToeBoard = new TicTacToeBoard();
            
            TicTacToeGameController ticTacToeGameController = new TicTacToeGameController(ticTacToeBoard, players);
            
            ConsoleGridGameView consoleGridGameView = new ConsoleGridGameView(ticTacToeGameController);
            
            consoleGridGameView.Controller.GameLoop();    
        }
    }
}
