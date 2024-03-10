using MorpionApp.Controllers;

namespace MorpionApp.Views.Interfaces;

public interface IGameView
{
    public GameController Controller { get; set; }
}