using MorpionApp.Models;
using MorpionApp.Controllers.Evaluators;
using MorpionApp.Models.Games.TicTacToe;
using Xunit;

namespace MorpionAppTest.Controllers.Evaluators;

[Trait("Category", "Evaluators")]
public class HorizontalLineEvaluatorTest
{
    [Fact]
    public void AlignmentTest()
    {
        // Arrange
        HorizontalLineEvaluator evaluator = new HorizontalLineEvaluator(3);
        TicTacToeBoard board = new TicTacToeBoard();
        HumanPlayer player = new HumanPlayer(1, "Player 1");
        TicTacToeToken token = new TicTacToeToken(player);
        
        
        board.putTokenInCase(new Position(0, 0), token);
        board.putTokenInCase(new Position(1, 0), token);
        board.putTokenInCase(new Position(2, 0), token);
        
        // Act
        bool res = evaluator.Evaluate(board, player);
        
        // Assert
        Assert.True(res);
    }
    
    [Fact]
    public void NoAlignmentTest()
    {
        // Arrange
        HorizontalLineEvaluator evaluator = new HorizontalLineEvaluator(3);
        TicTacToeBoard board = new TicTacToeBoard();
        HumanPlayer player = new HumanPlayer(1, "Player 1");
        TicTacToeToken token = new TicTacToeToken(player);
        
        
        board.putTokenInCase(new Position(0, 0), token);
        board.putTokenInCase(new Position(1, 0), token);
        board.putTokenInCase(new Position(2, 1), token);
        
        // Act
        bool res = evaluator.Evaluate(board, player);
        
        // Assert
        Assert.False(res);
    }
}