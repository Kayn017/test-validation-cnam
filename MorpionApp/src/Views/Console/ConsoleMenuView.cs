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
        DisplayGameList();
        ChooseGame();
    }
    private void DisplayGameList()
    {
        System.Console.WriteLine("Available games : ");
        System.Console.WriteLine("1. Morpion");
    }
    
    private void ChooseGame()
    {
        System.Console.WriteLine("Choose a game : ");
        string choice = System.Console.ReadLine();
        if (choice == "1")
        {
            MenuController.SelectedGame = Game.TicTacToe;
        }
        else
        {
            System.Console.WriteLine("Invalid choice");
        }
    }
}