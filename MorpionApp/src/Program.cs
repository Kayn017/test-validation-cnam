using MorpionApp.Controllers.Games;
using MorpionApp.Models;
using MorpionApp.Models.Games.TicTacToe;
using MorpionApp.Views;

namespace MorpionApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Coucou");
            
            // TODO : plus qu'a implémenter le déroulement d'une partie et le TicTacToe est fini (en principe)
            
            HumanPlayer[] players = new HumanPlayer[2];
            
            players[0] = new HumanPlayer(1, "Player 1");
            players[1] = new HumanPlayer(2, "Player 2");
            
            TicTacToeBoard ticTacToeBoard = new TicTacToeBoard();
            
            TicTacToeGameController ticTacToeGameController = new TicTacToeGameController(ticTacToeBoard, players);
            
            ConsoleGridGameView consoleGridGameView = new ConsoleGridGameView(ticTacToeGameController);
            
            consoleGridGameView.DrawGrid();
        }
    }
}
