using CreditImmo.Models;
using CreditImmo.Models.Interfaces;

namespace CreditImmo.Controllers;

public class CreditController
{
    protected ICredit Credit;
    
    public double MonthlyPayment => this.Credit.Amount * this.Credit.MonthlyRate / (1 - Math.Pow(1 + this.Credit.MonthlyRate, -this.Credit.Duration));
    
    public CreditController(ICredit credit)
    {
        this.Credit = credit;    
    }
    
    public void CalculatePayments()
    {
        double AmountToPay = this.Credit.Amount;
        
        for (int i = 1; i <= this.Credit.Duration; i++)
        {
            if(AmountToPay < this.MonthlyPayment)
            {
                this.Credit.Payments.Add(new MonthlyPayment(i, 0, this.Credit.Amount));
                break;
            }
            
            double interestPaid = AmountToPay * (this.Credit.MonthlyRate);
            double capitalPaid = this.MonthlyPayment - interestPaid;
            AmountToPay -= capitalPaid;
            
            this.Credit.Payments.Add(new MonthlyPayment(i, AmountToPay, this.Credit.Amount - AmountToPay));
        }
    }
}