using MorpionApp.Models;
using MorpionApp.Controllers.Evaluators;
using MorpionApp.Models.Games.TicTacToe;
using Xunit;

namespace MorpionAppTest.Controllers.Evaluators;

[Trait("Category", "Evaluators")]
public class VerticalLineEvaluatorTest
{
    [Fact]
    public void AlignmentTest()
    {
        // Arrange
        VerticalLineEvaluator evaluator = new VerticalLineEvaluator(3);
        TicTacToeBoard board = new TicTacToeBoard();
        HumanPlayer player = new HumanPlayer(1, "Player 1");
        TicTacToeToken token = new TicTacToeToken(player);
        
        
        board.putTokenInCase(new Position(0, 0), token);
        board.putTokenInCase(new Position(0, 1), token);
        board.putTokenInCase(new Position(0, 2), token);
        
        // Act
        bool res = evaluator.Evaluate(board, player);
        
        // Assert
        Assert.True(res);
    }
    
    [Fact]
    public void NoAlignmentTest()
    {
        // Arrange
        VerticalLineEvaluator evaluator = new VerticalLineEvaluator(3);
        TicTacToeBoard board = new TicTacToeBoard();
        HumanPlayer player = new HumanPlayer(1, "Player 1");
        TicTacToeToken token = new TicTacToeToken(player);
        
        
        board.putTokenInCase(new Position(0, 0), token);
        board.putTokenInCase(new Position(0, 1), token);
        board.putTokenInCase(new Position(2, 2), token);
        
        // Act
        bool res = evaluator.Evaluate(board, player);
        
        // Assert
        Assert.False(res);
    }
}