using MorpionApp.Controllers;
using MorpionApp.Controllers.Enums;
using MorpionApp.Models;
using MorpionApp.Controllers.Factory;
using MorpionApp.Controllers.Games;
using Xunit;

namespace MorpionAppTest.Controllers.Factory;

public class GameControllerFactoryTest
{
    [Fact]
    public void CreateTicTacToeGameControllerTest()
    {
        // Arrange
        Game game = Game.TicTacToe;
        Player[] players = new Player[2];
        players[0] = new HumanPlayer(1, "Player 1");
        players[1] = new HumanPlayer(2, "Player 2");
        
        // Act
        GameController controller = GameControllerFactory.CreateGameController(game, players);
        
        // Assert
        Assert.IsType<TicTacToeGameController>(controller);
    }
    
    [Fact]
    public void CreateConnectFourGameControllerTest()
    {
        // Arrange
        Game game = Game.ConnectFour;
        Player[] players = new Player[2];
        players[0] = new HumanPlayer(1, "Player 1");
        players[1] = new HumanPlayer(2, "Player 2");
        
        // Act
        GameController controller = GameControllerFactory.CreateGameController(game, players);
        
        // Assert
        Assert.IsType<ConnectFourGameController>(controller);
    }
}