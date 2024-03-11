using MorpionApp.Controllers;
using MorpionApp.Controllers.Enums;

namespace MorpionApp.Models;

public class HumanPlayer : Player
{
    public HumanPlayer(int id, string name) : base(id, name)
    {}
    
    public override string ToString()
    {
        return this.Name;
    }
    
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        
        HumanPlayer other = (HumanPlayer) obj;
        
        return this.Id == other.Id && this.Name == other.Name;
    }

    public override void Play(GameController gameController)
    {
        gameController.EventManager.notify(EventTypes.UserInput);
    }
}