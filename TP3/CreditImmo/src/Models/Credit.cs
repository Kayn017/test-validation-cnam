using CreditImmo.Controllers.Interfaces;
using CreditImmo.Models.Interfaces;

namespace CreditImmo.Models;

public class Credit : ICredit, IArgumentInjectable, ISerialisable
{
    public double Amount { get; set; }
    public double Rate { get; set; }
    public int Duration { get; set; }
    public List<MonthlyPayment> Payments { get; protected set; }
    public double MonthlyRate => Rate / 12 / 100;
    
    public Credit(double amount, double rate, int duration)
    {
        Amount = amount;
        Rate = rate;
        Duration = duration;
        Payments = new List<MonthlyPayment>();
    }
    
    public Credit() {}
    
    public void Initialize(Dictionary<string, string> args)
    {
        Amount = double.Parse(args["amount"]);
        Rate = double.Parse(args["rate"]);
        Duration = int.Parse(args["duration"]);
        
        this.Payments = new List<MonthlyPayment>();
    }

    public void Serialize(ISerializer serializer)
    {
        this.Payments.ForEach( payment => payment.Serialize(serializer) );
    }
}