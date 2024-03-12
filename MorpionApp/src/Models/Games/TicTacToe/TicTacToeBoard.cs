namespace MorpionApp.Models.Games.TicTacToe;

public class TicTacToeBoard : Board
{
    public override int NbRow { get; protected set; } = 3;
    public override int NbColumn { get; protected set; } = 3;
    
    public override bool playable(Position position)
    {
        return this.inBounds(position) && this.Grid[position.Y, position.X].Empty;
    }
}