using MorpionApp.Models.Interfaces;

namespace MorpionApp.Models;

public class Case
{
    public IToken? Token { get; set; }

    public bool Empty => this.Token == null;

    public Case() {}
    
    public Case(IToken token)
    {
        this.Token = token;
    }
}