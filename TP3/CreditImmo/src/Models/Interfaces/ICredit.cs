namespace CreditImmo.Models.Interfaces;

public interface ICredit
{
    double Amount { get; set; }
    double Rate { get; set; }
    int Duration { get; set; }
    
    List<MonthlyPayment> Payments { get; }
    
    double MonthlyRate { get; }
}