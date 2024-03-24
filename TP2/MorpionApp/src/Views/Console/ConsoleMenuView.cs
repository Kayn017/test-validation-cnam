using MorpionApp.Controllers;
using MorpionApp.Controllers.Enums;
using MorpionApp.Views.Interfaces;

namespace MorpionApp.Views.Console;

public class ConsoleMenuView : IMenuView
{
    public MenuController MenuController { get; set; }
    
    public ConsoleMenuView(MenuController menuController)
    {
        MenuController = menuController;
    }

    public void Show()
    {
        this.DisplayGameList();
        
        while (this.MenuController.SelectedGame == Game.None)
        {
            this.ChooseGame();
        }
        
        // TODO : s'occuper de jeux aux nombres de joueurs supérieur à 2
        while (this.MenuController.Players.Count < 2)
        {
            this.DisplayPlayerTypeList();
            this.CreatePlayer();
        }
        
        this.MenuController.StartGame();
    }
    public void DisplayGameList()
    {
        System.Console.WriteLine("Available games : ");
        System.Console.WriteLine("1. Tic Tac Toe");
        System.Console.WriteLine("2. Connect Four");
    }
    
    public void ChooseGame()
    {
        System.Console.WriteLine("Choose a game : ");
        string choice = System.Console.ReadLine();
        if (choice.Contains("1"))
        {
            MenuController.SelectedGame = Game.TicTacToe;
        }
        else if (choice.Contains("2"))
        {
            MenuController.SelectedGame = Game.ConnectFour;
        }
        else
        {
            System.Console.WriteLine("Invalid choice");
        }
    }
    
    public void DisplayPlayerTypeList()
    {
        System.Console.WriteLine("Available player type : ");
        System.Console.WriteLine("1. Human");
        System.Console.WriteLine("2. AI");
    }

    
    public void CreatePlayer()
    {
        System.Console.WriteLine("Choose a player type :");
        string choice = System.Console.ReadLine();
        PlayerTypes type;
        if (choice.Contains("1"))
        {
            type = PlayerTypes.Human;
        }
        else 
        {
            type = PlayerTypes.Computer;
        }

        string name = "Gros joueur";

        if (type == PlayerTypes.Human)
        {
            System.Console.WriteLine("Enter player name : ");
            name = System.Console.ReadLine();
        }

        try
        {
            this.MenuController.AddPlayer(type, name);
        }
        catch (ArgumentException exception)
        {
            System.Console.WriteLine("Veuillez entrer un nom valide");
        }
    }
}