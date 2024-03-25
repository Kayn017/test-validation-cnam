using System;
using CreditImmo.Controllers;
using CreditImmo.Models;
using Xunit;

namespace TP3.Controllers;

public class CreditControllerTest
{
    [Theory]
    [InlineData(100000, 3.73, 25 * 12, 513.04)]
    [InlineData(100000, 3.60, 20 * 12, 585.11)]
    [InlineData(100000, 3.49, 15 * 12, 714.39)]
    public void TestMonthlyPayment(double amount, double rate, int duration, double expectedResult)
    {
        Credit credit = new Credit(amount, rate, duration);
        CreditController creditController = new CreditController(credit);
        
        Assert.Equal(expectedResult, Math.Round(creditController.MonthlyPayment, 2));
    }

    [Theory]
    [InlineData(100000, 3.73, 25 * 12, 99797.79, 202.21)]
    [InlineData(100000, 3.60, 20 * 12, 99714.89, 285.11)]
    [InlineData(100000, 3.49, 15 * 12, 99576.44, 423.56)]
    public void TestCalculatePayments(double amount, double rate, int duration, double expectedAmountToPay, double expectedAmountPaid)
    {
        Credit credit = new Credit(amount, rate, duration);
        CreditController creditController = new CreditController(credit);
        
        creditController.CalculatePayments();
        
        Assert.Equal(expectedAmountToPay, Math.Round(credit.Payments[0].AmountToPay, 2));
        Assert.Equal(expectedAmountPaid, Math.Round(credit.Payments[0].AmountPaid, 2));
    }
}