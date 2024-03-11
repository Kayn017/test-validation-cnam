using MorpionApp.Controllers.Interfaces;
using MorpionApp.Models;

namespace MorpionApp.Controllers;

public abstract class GameController
{
    public readonly EventManager EventManager;

    public Player[] Players { get; protected set; }
    public Board Board { get; protected set; }
    public bool isEnded { get; set; }
    
    public abstract int MinNbPlayers { get; }
    public abstract int MaxNbPlayers { get; }
    
    private int currentPlayerIdx;
    public Player CurrentPlayer => this.Players[this.currentPlayerIdx];

    public IEvaluator[] WinConditions { get; protected set; }
    
    protected GameController(Board board, Player[] players)
    {
        if(players.Length < this.MinNbPlayers || players.Length > this.MaxNbPlayers)
            throw new ArgumentOutOfRangeException("Invalid number of players");
        
        this.Board = board;
        this.Players = players;
        this.currentPlayerIdx = 0;
        this.EventManager = new EventManager();
    }

    public abstract bool CheckWin();
    public abstract void Play(Position position);
    public abstract void GameLoop();
    
    public void NextPlayer()
    {
        this.currentPlayerIdx = (this.currentPlayerIdx + 1) % this.Players.Length;
        this.CurrentPlayer.Play(this);
    }
}