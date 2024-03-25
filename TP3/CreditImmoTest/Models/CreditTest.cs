using System.Collections;
using System.Collections.Generic;
using CreditImmo.Models;
using Xunit;

namespace TP3.Models;

public class CreditTest
{
    [Theory]
    [InlineData(1, 1000, 100)]
    public void TestCredit(double amount, double rate, int duration)
    {
        Credit credit = new Credit(amount, rate, duration);

        Assert.Equal(amount, credit.Amount);
        Assert.Equal(rate, credit.Rate);
        Assert.Equal(duration, credit.Duration);

        Assert.NotNull(credit.Payments);
        Assert.Empty(credit.Payments);
    }

    public static IEnumerable ArgCredit =>
        new List<Dictionary<string, string>>
        {
            new()
            {
                { "amount", "1000" },
                { "rate", "1" },
                { "duration", "1" }
            },
            new()
            {
                { "amount", "200000" },
                { "rate", "5.6" },
                { "duration", "1" }
            },
        };

    [Theory]
    [MemberDataAttribute(nameof(ArgCredit))]
    public void TestInitializeCredit(Dictionary<string, string> data)
    {
        Credit credit = new Credit();
        credit.Initialize(data);
        
        Assert.Equal(double.Parse(data["amount"]), credit.Amount);
        Assert.Equal(double.Parse(data["rate"]), credit.Rate);
        Assert.Equal(int.Parse(data["duration"]), credit.Duration);
        
        Assert.NotNull(credit.Payments);
        Assert.Empty(credit.Payments);
    }
    
    [Theory]
    [InlineData(4.5, 0.00375)]
    [InlineData(1.5, 0.00125)]
    public void TestCreditMonthlyRate( double rate, double expected )
    {
        Credit credit = new Credit(1000, rate, 1);

        Assert.Equal(expected, credit.MonthlyRate);
    }
}