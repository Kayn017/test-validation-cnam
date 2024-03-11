using MorpionApp.Controllers;

namespace MorpionApp.Models;

public abstract class Player
{
    public int Id { get; }
    public string Name { get; }
    
    public Player(int id, string name)
    {
        this.Id = id;
        this.Name = name;
    }

    public abstract void Play(GameController gameController);
}