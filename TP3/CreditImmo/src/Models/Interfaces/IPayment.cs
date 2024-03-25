namespace CreditImmo.Models.Interfaces;

public interface IPayment
{
    public static int NbPaymentInAYear { get; }
    public int Number { get; set; }
    public double AmountToPay { get; set; }
    public double AmountPaid { get; set; }
}