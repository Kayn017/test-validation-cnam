namespace MorpionApp.Models.Games.TicTacToe;

public class TicTacToeBoard : Board
{
    public TicTacToeBoard()
    {
        this.Grid = new Case[3, 3];
        
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                this.Grid[i, j] = new Case();
            }
        }
    }
    
    public override bool playable(Position position)
    {
        return this.inBounds(position) && this.Grid[position.X, position.Y].Empty;
    }
}