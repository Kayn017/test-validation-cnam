using MorpionApp.Controllers.Interfaces;
using MorpionApp.Models;

namespace MorpionApp.Controllers.Evaluators;

public abstract class AbstractLineAlignementEvaluator : IEvaluator
{
    public abstract bool Evaluate(Board board, Player player);

    protected int CheckMaxConsecutive(Board board, Player player, int startRow, int startCol, int rowStep, int colStep)
    {
        int nbTokensAligned = 0;
        int maxNbTokensAligned = 0;
        
        for(int row = 0, col = 0; row < board.NbRow && col < board.NbColumn && row >= 0 && col >= 0; row += rowStep, col += colStep)
        {
            if (player.Equals(board.Grid[startRow + row, startCol + col].Token?.Player))
            {
                nbTokensAligned++;
                maxNbTokensAligned = Math.Max(maxNbTokensAligned, nbTokensAligned);
            }
            else
            {
                nbTokensAligned = 0;
            }
        }

        return maxNbTokensAligned;
    }
}