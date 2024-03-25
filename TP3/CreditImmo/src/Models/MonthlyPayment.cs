using CreditImmo.Controllers.Interfaces;
using CreditImmo.Models.Interfaces;

namespace CreditImmo.Models;

public class MonthlyPayment : IPayment, ISerialisable
{
    public static int NbPaymentInAYear { get; } = 12;
    public int Number { get; set; }
    public double AmountToPay { get; set; }
    public double AmountPaid { get; set; }

    public MonthlyPayment(int number, double amountToPay, double amountPaid)
    {
        Number = number;
        AmountToPay = amountToPay;
        AmountPaid = amountPaid;
    }

    public void Serialize(ISerializer serializer)
    {
        serializer.Serialize(Number.ToString(), AmountToPay.ToString(), AmountPaid.ToString());
    }
}