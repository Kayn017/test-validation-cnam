using MorpionApp.Models;

namespace MorpionApp.Controllers.Evaluators;

public class HorizontalLineEvaluator : AbstractLineAlignementEvaluator
{
    private int NbTokensToAlign { get; } 

    public HorizontalLineEvaluator(int nbTokensToAlign)
    {
        this.NbTokensToAlign = nbTokensToAlign;
    }
    
    public override bool Evaluate(Board board, Player player)
    {
        bool res = false;
        
        for (int i = 0; i < board.rowCount; i++)
        {
            res = res || (this.checkMaxConsecutive(board, player, i, 0, 0, 1) >= this.NbTokensToAlign);
        }
        
        return res;
    }
}