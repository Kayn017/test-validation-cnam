using MorpionApp.Models.Interfaces;

namespace MorpionApp.Models.Games.TicTacToe;

public class TicTacToeToken : IToken
{
    public Player Player { get; }
    public string Value { get; set; }

    public TicTacToeToken(Player player)
    {
        this.Player = player;
        // In TicTacToe, all tokens have the same value
        this.Value = player.Id % 2 == 0 ? "O" : "X";
    }
}