using MorpionApp.Controllers.Enums;
using MorpionApp.Controllers.Factory;
using MorpionApp.Models;

namespace MorpionApp.Controllers;

public class MenuController
{
    public GameController Controller { get; set; }
    public Game SelectedGame { get; set; }
    public Player[] Players { get; set; }

    public void StartGame()
    {
        if (this.SelectedGame == null || this.Players == null)
        {
            throw new InvalidOperationException("Game and players must be selected before starting the game");
        }
        
        this.Controller = GameControllerFactory.CreateGameController(this.SelectedGame, this.Players);
    }
}