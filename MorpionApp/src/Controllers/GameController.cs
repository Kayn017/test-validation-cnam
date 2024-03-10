using MorpionApp.Controllers.Interfaces;
using MorpionApp.Models;

namespace MorpionApp.Controllers;

public abstract class GameController
{
    public EventManager EventManager;

    protected Player[] Players { get; }
    public Board Board { get; protected set; }
    
    private int currentPlayerIdx;
    public Player CurrentPlayer => this.Players[this.currentPlayerIdx];

    public IEvaluator[] WinConditions { get; protected set; }
    
    protected GameController(Player[] players)
    {
        this.currentPlayerIdx = 0;
        this.Players = players;
        this.EventManager = new EventManager();
    }

    public abstract bool CheckWin();
    public abstract void Play(Position position);
    
    public void NextPlayer()
    {
        this.currentPlayerIdx = (this.currentPlayerIdx + 1) % this.Players.Length;
    }
}