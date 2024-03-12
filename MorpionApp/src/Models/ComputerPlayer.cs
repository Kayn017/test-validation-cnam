using MorpionApp.Controllers;
using MorpionApp.Controllers.Enums;
using MorpionApp.Models.Exceptions;

namespace MorpionApp.Models;

public class ComputerPlayer : Player
{
    public ComputerPlayer(string name): base(0, name)
    {}
    
    public ComputerPlayer(int id, string name) : base(id, name)
    {}
    
    public override void Play(GameController gameController)
    {
        Random random = new Random();

        while(true)
        {
            int x = random.Next(0, gameController.Board.NbColumn);
            int y = random.Next(0, gameController.Board.NbRow);

            try
            {
                gameController.Play(new Position(x, y));
                break;
            }
            catch(InvalidMoveException exception) {}
        }
    }
    
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }
        
        ComputerPlayer other = (ComputerPlayer) obj;
        
        return this.Id == other.Id && this.Name == other.Name;
    }

}