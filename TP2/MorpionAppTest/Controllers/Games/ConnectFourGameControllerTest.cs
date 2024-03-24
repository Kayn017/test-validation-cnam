using System;
using System.Collections.Generic;
using MorpionApp.Controllers.Games;
using MorpionApp.Models;
using MorpionApp.Models.Exceptions;
using MorpionApp.Models.Games.ConnectFour;
using Xunit;

namespace MorpionAppTest.Controllers.Games;

public class ConnectFourGameControllerTest
{
    public ConnectFourGameController connectFourGameController;
    
    public ConnectFourGameControllerTest()
    {
        ConnectFourBoard board = new ConnectFourBoard();
        
        ComputerPlayer[] players = new ComputerPlayer[]
        {
            new ComputerPlayer("Player 1"),
            new ComputerPlayer("Player 2")
        };
        
        connectFourGameController = new ConnectFourGameController(board, players);
    }
    
    [Fact]
    public void CheckNoWin()
    {
        // Arrange
        // Act
        bool result = connectFourGameController.CheckWin();
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void CheckWin()
    {
        // Arrange
        connectFourGameController.Board.putTokenInCase(new Position(0, 0), new ConnectFourToken(connectFourGameController.CurrentPlayer));
        connectFourGameController.Board.putTokenInCase(new Position(0, 1), new ConnectFourToken(connectFourGameController.CurrentPlayer));
        connectFourGameController.Board.putTokenInCase(new Position(0, 2), new ConnectFourToken(connectFourGameController.CurrentPlayer));
        connectFourGameController.Board.putTokenInCase(new Position(0, 3), new ConnectFourToken(connectFourGameController.CurrentPlayer));
        // Act
        bool result = connectFourGameController.CheckWin();
        // Assert
        Assert.True(result);
    }

    [Fact]
    public void CanPlay()
    {
        // Arrange
        Position position = new Position(1, 1);
        
        // Act       
        // Assert
        Assert.Null(Record.Exception(() => connectFourGameController.Play(position)));
    }

    [Fact]
    public void CannotPlay()
    {
        // Arrange
        Position position = new Position(6, 6);
        connectFourGameController.Board.putTokenInCase(position, new ConnectFourToken(connectFourGameController.CurrentPlayer));
        
        // Act             
        // Assert
        Assert.Throws<InvalidMoveException>(() => connectFourGameController.Play(position));
    }
    
    public static IEnumerable<object[]> MoveCursorData =>
        new List<object[]>
        {
            new object[] { ConsoleKey.LeftArrow, new Position(1, 0) },
            new object[] { ConsoleKey.RightArrow, new Position(3, 0) },
            new object[] { ConsoleKey.UpArrow, new Position(2, 0) },
            new object[] { ConsoleKey.DownArrow, new Position(2, 0) }
        };
    
    [Theory]
    [MemberData(nameof(MoveCursorData))]
    public void MoveCursor(ConsoleKey key, Position expected)
    {
        // Arrange
        Position cursor = new Position(2, 0);
        
        // Act
        Position result = connectFourGameController.moveCursor(cursor, key);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void PlayToken()
    {   
        // Arrange
        Position position = new Position(0, 0);
        
        // Act
        Player player = connectFourGameController.CurrentPlayer;
        connectFourGameController.moveCursor(position, ConsoleKey.Enter);

        var res = connectFourGameController.Board.getCase(position);
        
        // Assert
        Assert.Equal(player, res.Token?.Player);
    }
}