using System;
using System.Collections.Generic;
using MorpionApp.Controllers.Games;
using MorpionApp.Models;
using MorpionApp.Models.Exceptions;
using MorpionApp.Models.Games.ConnectFour;
using MorpionApp.Models.Games.TicTacToe;
using Xunit;

namespace MorpionAppTest.Controllers.Games;

public class TicTacToeGameControllerTest
{
    public TicTacToeGameController TicTacToeGameController;
    
    public TicTacToeGameControllerTest()
    {
        TicTacToeBoard board = new TicTacToeBoard();
        
        ComputerPlayer[] players = new ComputerPlayer[]
        {
            new ComputerPlayer("Player 1"),
            new ComputerPlayer("Player 2")
        };
        
        this.TicTacToeGameController = new TicTacToeGameController(board, players);
    }
    
    [Fact]
    public void CheckNoWin()
    {
        // Arrange
        // Act
        bool result = this.TicTacToeGameController.CheckWin();
        // Assert
        Assert.False(result);
    }
    
    [Fact]
    public void CheckWin()
    {
        // Arrange
        this.TicTacToeGameController.Board.putTokenInCase(new Position(0, 0), new ConnectFourToken(this.TicTacToeGameController.CurrentPlayer));
        this.TicTacToeGameController.Board.putTokenInCase(new Position(0, 1), new ConnectFourToken(this.TicTacToeGameController.CurrentPlayer));
        this.TicTacToeGameController.Board.putTokenInCase(new Position(0, 2), new ConnectFourToken(this.TicTacToeGameController.CurrentPlayer));
        // Act
        bool result = this.TicTacToeGameController.CheckWin();
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
        Assert.Null(Record.Exception(() => this.TicTacToeGameController.Play(position)));
    }

    [Fact]
    public void CannotPlay()
    {
        // Arrange
        Position position = new Position(1, 1);
        this.TicTacToeGameController.Board.putTokenInCase(position, new ConnectFourToken(this.TicTacToeGameController.CurrentPlayer));
        
        // Act             
        // Assert
        Assert.Throws<InvalidMoveException>(() => this.TicTacToeGameController.Play(position));
    }
    
    public static IEnumerable<object[]> MoveCursorData =>
        new List<object[]>
        {
            new object[] { ConsoleKey.LeftArrow, new Position(0, 1) },
            new object[] { ConsoleKey.RightArrow, new Position(2, 1) },
            new object[] { ConsoleKey.UpArrow, new Position(1, 0) },
            new object[] { ConsoleKey.DownArrow, new Position(1, 2) }
        };
    
    [Theory]
    [MemberData(nameof(MoveCursorData))]
    public void MoveCursor(ConsoleKey key, Position expected)
    {
        // Arrange
        Position cursor = new Position(1, 1);
        
        // Act
        Position result = this.TicTacToeGameController.moveCursor(cursor, key);
        
        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void PlayToken()
    {   
        // Arrange
        Position position = new Position(0, 0);
        
        // Act
        Player player = this.TicTacToeGameController.CurrentPlayer;
        this.TicTacToeGameController.moveCursor(position, ConsoleKey.Enter);

        var res = this.TicTacToeGameController.Board.getCase(position);
        
        // Assert
        Assert.Equal(player, res.Token?.Player);
    }
}