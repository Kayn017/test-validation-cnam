using CreditImmo.Models.Interfaces;

namespace CreditImmo.Controllers;

public abstract class ArgumentParser
{
    public string[] args { get; set; }
    public abstract int ArgumentCount { get; }
    
    public ArgumentParser(string[] args)
    {
        if(args == null || args.Length < this.ArgumentCount)
        {
            throw new ArgumentException(Usage());
        }
        
        this.args = args;
    }

    public abstract string Usage();
    
    public abstract IArgumentInjectable Create();
}