using MorpionApp.Models;

namespace MorpionApp.Controllers.Evaluators;

public class VerticalLineEvaluator : AbstractLineAlignementEvaluator
{
    private int NbTokensToAlign { get; } 

    public VerticalLineEvaluator(int nbTokensToAlign)
    {
        this.NbTokensToAlign = nbTokensToAlign;
    }
    
    public override bool Evaluate(Board board, Player player)
    {     
        bool res = false;
        
        for (int i = 0; i < board.columnCount; i++)
        {
            res = res || (this.checkMaxConsecutive(board, player, 0, i, 1, 0) >= this.NbTokensToAlign);
        }
        
        return res;
    }
}