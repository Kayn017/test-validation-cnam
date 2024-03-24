using MorpionApp.Models.Interfaces;

namespace MorpionApp.Models;

public abstract class Board
{
    public Case[,] Grid { get; protected set; }
    
    public bool inBounds(Position position) => position.X >= 0 && position.X < this.Grid.GetLength(1) && position.Y >= 0 && position.Y < this.Grid.GetLength(0);

    public abstract int NbRow { get; protected set; }
    public abstract int NbColumn { get; protected set; }

    public Board()
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
    
    public abstract bool playable(Position position);
    public Case getCase(Position position) => this.Grid[position.Y, position.X];
    
    public virtual bool putTokenInCase(Position position, IToken token)
    {
        if (!this.playable(position))
        {
            return false;
        }
        
        this.Grid[position.Y, position.X].Token = token;
        return true;
    }
    
}
