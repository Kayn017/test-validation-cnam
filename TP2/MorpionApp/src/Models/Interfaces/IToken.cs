namespace MorpionApp.Models.Interfaces;

public interface IToken
{
    public Player Player { get; }
    public string Value { get; set; }
}