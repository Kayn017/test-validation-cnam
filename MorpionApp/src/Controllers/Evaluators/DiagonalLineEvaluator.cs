using MorpionApp.Controllers.Interfaces;
using MorpionApp.Models;
using MorpionApp.Views.Interfaces;

namespace MorpionApp.Controllers.Evaluators;

public class DiagonalLineEvaluator : AbstractLineAlignementEvaluator
{
    private int NbTokensToAlign { get; } 

    public DiagonalLineEvaluator(int nbTokensToAlign)
    {
        this.NbTokensToAlign = nbTokensToAlign;
    }
    
    public override bool Evaluate(Board board, Player player)
    {
        bool res = false;
        int maxCol = board.rowCount - board.columnCount;
        
        for (int i = 0; i < maxCol; i++)
        {
            res = res || (this.checkMaxConsecutive(board, player, 0, i, 1, 1) >= this.NbTokensToAlign);
            res = res || (this.checkMaxConsecutive(board, player, 0, i, -1, 1) >= this.NbTokensToAlign);
            res = res || (this.checkMaxConsecutive(board, player, board.rowCount - 1, i, -1, 1) >= this.NbTokensToAlign);
            res = res || (this.checkMaxConsecutive(board, player, board.rowCount - 1, i, -1, -1) >= this.NbTokensToAlign);
        }
        
        return res;
    }
}