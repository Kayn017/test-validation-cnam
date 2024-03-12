using MorpionApp.Controllers;

namespace MorpionApp.Models;

public abstract class Player
{
    public int Id { get; set; }
    public string Name { get; set;  }
    
    public Player(int id, string name)
    {
        this.Id = id;
        this.Name = name;
    }

    public abstract void Play(GameController gameController);
}