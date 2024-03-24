using MorpionApp.Models.Interfaces;

namespace MorpionApp.Models.Games.ConnectFour;

public class ConnectFourToken : IToken
{
    public Player Player { get; }
    public string Value { get; set; }
    
    public ConnectFourToken(Player player)
    {
        this.Player = player;
        this.Value = player.Id % 2 == 0 ? "O" : "X";
    }
}