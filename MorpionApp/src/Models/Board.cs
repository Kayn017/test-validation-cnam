using MorpionApp.Models.Interfaces;

namespace MorpionApp.Models;

public abstract class Board
{
    public Case[,] Grid { get; protected set; }
    
    public bool inBounds(Position position) => position.X >= 0 && position.X < this.Grid.GetLength(0) && position.Y >= 0 && position.Y < this.Grid.GetLength(1);

    public int rowCount => this.Grid.GetLength(0);
    public int columnCount => this.Grid.GetLength(1);
    
    public abstract bool playable(Position position);
    public Case getCase(Position position) => this.Grid[position.X, position.Y];

    public Case[] getRow(int row)
    {
        Case[] result = new Case[this.Grid.GetLength(1)];
        
        for (int i = 0; i < this.Grid.GetLength(1); i++)
        {
            result[i] = this.Grid[row, i];
        }

        return result;
    }
    
    public Case[] getColumn(int column)
    {
        Case[] result = new Case[this.Grid.GetLength(0)];
        
        for (int i = 0; i < this.Grid.GetLength(0); i++)
        {
            result[i] = this.Grid[i, column];
        }

        return result;
    }
    
    public bool putTokenInCase(Position position, IToken token)
    {
        if (!this.playable(position))
        {
            return false;
        }
        
        this.Grid[position.X, position.Y].Token = token;
        return true;
    }
    
}
