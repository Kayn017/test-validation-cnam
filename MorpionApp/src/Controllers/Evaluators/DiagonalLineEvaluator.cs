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
        
        for (int i = 0; i <= board.NbColumn; i++)
        {
            res = res || (this.CheckMaxConsecutive(board, player, 0, i, 1, 1) >= this.NbTokensToAlign);
            res = res || (this.CheckMaxConsecutive(board, player, 0, i, -1, 1) >= this.NbTokensToAlign);
            res = res || (this.CheckMaxConsecutive(board, player, board.NbRow - 1, i, -1, 1) >= this.NbTokensToAlign);
            res = res || (this.CheckMaxConsecutive(board, player, board.NbRow - 1, i, -1, -1) >= this.NbTokensToAlign);
        }
        
        return res;
    }
}