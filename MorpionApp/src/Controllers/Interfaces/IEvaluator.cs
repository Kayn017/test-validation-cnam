using MorpionApp.Models;

namespace MorpionApp.Controllers.Interfaces;

public interface IEvaluator
{
    public bool Evaluate(Board board, Player player);
}