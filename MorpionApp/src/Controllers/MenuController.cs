using System.Collections;
using MorpionApp.Controllers.Enums;
using MorpionApp.Controllers.Factory;
using MorpionApp.Models;
using MorpionApp.Views.Console;
using MorpionApp.Views.Interfaces;

namespace MorpionApp.Controllers;

public class MenuController
{
    public GameController Controller { get; set; }
    public Game SelectedGame { get; set; } = Game.None;
    public List<Player> Players { get; set; }
    
    public MenuController()
    {
        this.Players = new List<Player>();
    }

    public void StartGame()
    {
        if (this.SelectedGame == Game.None || this.Players == null)
        {
            throw new InvalidOperationException("Game and players must be selected before starting the game");
        }
        
        this.Controller = GameControllerFactory.CreateGameController(this.SelectedGame, this.Players.ToArray());
        
        // TODO : Prendre en compte dans le futur les différents types de vues
        IGameView gameView = new ConsoleGridGameView(this.Controller);
        
        this.Controller.GameLoop();
    }

    public void AddPlayer(PlayerTypes type, string name)
    {
        if (name == String.Empty)
        {
            throw new ArgumentException("Name cannot be empty");
        }
        
        this.Players.Add(PlayerFactory.CreatePlayer(type, name));
    }
}