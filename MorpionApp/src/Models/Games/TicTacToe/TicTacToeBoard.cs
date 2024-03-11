namespace MorpionApp.Models.Games.TicTacToe;

public class TicTacToeBoard : Board
{
    public override int NbRow { get; protected set; } = 3;
    public override int NbColumn { get; protected set; } = 3;
    
    public TicTacToeBoard()
    {
        this.Grid = new Case[this.NbRow, this.NbColumn];
        
        for (int i = 0; i < this.NbRow; i++)
        {
            for (int j = 0; j < this.NbColumn; j++)
            {
                this.Grid[i, j] = new Case();
            }
        }
    }
    
    public override bool playable(Position position)
    {
        return this.inBounds(position) && this.Grid[position.Y, position.X].Empty;
    }
}