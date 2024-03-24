using MorpionApp.Controllers.Enums;
using MorpionApp.Models;

namespace MorpionApp.Controllers.Factory;

public class PlayerFactory
{
    public static Player CreatePlayer(PlayerTypes playerTypes, string name)
    {
        Player player;
        
        switch (playerTypes)
        {
            case PlayerTypes.Human:
                player = new HumanPlayer(name);
                break;
            case PlayerTypes.Computer:
                player = new ComputerPlayer(name);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return player;
    }
}