using MorpionApp.Controllers.Enums;
using MorpionApp.Models;
using MorpionApp.Controllers.Factory;
using Xunit;

namespace MorpionAppTest.Controllers.Factory;

public class PlayerFactoryTest
{
    [Fact]
    public void CreateHumanPlayer()
    {
        // Arrange
        // Act
        Player player = PlayerFactory.CreatePlayer(PlayerTypes.Human, "Player");        
        // Assert
        Assert.IsType<HumanPlayer>(player);
    }
    
    [Fact]
    public void CreateComputerPlayer()
    {
        // Arrange
        // Act
        Player player = PlayerFactory.CreatePlayer(PlayerTypes.Computer, "Player");        
        // Assert
        Assert.IsType<ComputerPlayer>(player);
    }
}