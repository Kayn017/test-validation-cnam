using Xunit;

using CreditImmo.Models;

namespace TP3.Models;

public class MonthlyPaymentTest
{
    [Theory]
    [InlineData(1, 1000, 100)]
    [InlineData(2, 200, 10)]
    public void TestMonthlyPayment(int number, double amountToPay, double amountPaid)
    {
        MonthlyPayment monthlyPayment = new MonthlyPayment(number, amountToPay, amountPaid);
        Assert.Equal(number, monthlyPayment.Number);
        Assert.Equal(amountToPay, monthlyPayment.AmountToPay);
        Assert.Equal(amountPaid, monthlyPayment.AmountPaid);
    }
}