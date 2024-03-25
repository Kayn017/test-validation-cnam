using CreditImmo.Models;
using CreditImmo.Models.Interfaces;

namespace CreditImmo.Controllers;

public class CreditArgumentParser : ArgumentParser
{
    public static readonly int MIN_AMOUNT = 50000;
    public static readonly int MIN_DURATION = 9 * 12;
    public static readonly int MAX_DURATION = 25 * 12;
    
    public override int ArgumentCount { get; } = 3;
    
    public CreditArgumentParser(string[] args) : base(args)
    {
        if (!double.TryParse(args[0], out double amount) || amount < MIN_AMOUNT)
        {
            throw new ArgumentException("Amount must be a number and greater than 50 000");
        }
        
        if (!int.TryParse(args[1], out int duration) || duration < MIN_DURATION || duration > MAX_DURATION)
        {
            throw new ArgumentException($"Duration must be a number and between {MIN_DURATION} and {MAX_DURATION}");
        }
    }

    public override string Usage()
    {
        return "Usage: CreditImmo <amount> <years> <rate>";
    }

    public override Credit Create()
    {
        Credit res = new Credit();
        
        res.Initialize(new Dictionary<string, string>
        {
            ["amount"] = this.args[0],
            ["duration"] = this.args[1],
            ["rate"] = this.args[2]
        });
        
        return res;
    }
}