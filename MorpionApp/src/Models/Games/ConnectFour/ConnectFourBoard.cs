using MorpionApp.Models.Interfaces;

namespace MorpionApp.Models.Games.ConnectFour;

public class ConnectFourBoard : Board
{
    public override int NbRow { get; protected set; } = 6;
    public override int NbColumn { get; protected set; } = 7;
    
    public override bool playable(Position position)
    {
        return this.inBounds(position) && !this.isColumnFull(position.X);
    }
    
    public bool isColumnFull(int column)
    {
        return !this.Grid[0, column].Empty;
    }
    
    public override bool putTokenInCase(Position position, IToken token)
    {
        if (!this.playable(position))
            return false;
        
        int row = this.getEmptyRow(position.X);

        if (row == -1)
            return false;
        
        this.Grid[row, position.X].Token = token;
        return true;
    }
    
    private int getEmptyRow(int column)
    {
        for (int i = this.NbRow - 1; i >= 0; i--)
        {
            if (this.Grid[i, column].Empty)
                return i;
        }
        
        return -1;
    }
}