using System;
using System.Collections;
using System.Collections.Generic;
using CreditImmo.Controllers;
using Xunit;

namespace TP3.Controllers;

public class CreditArgumentParserTest
{
    public static IEnumerable WrongStringArgs =>
        new List<string[][]>
        {
            new[] { new[] { "1000", "1", "1" } },
            new[] { new[] { "20000", "330", "1.4" } },
            new[] { new[] { "49999", "90", "0" } },
        };
    
    [Theory]
    [MemberData(nameof(WrongStringArgs))]
    public void CannotCreateCreditForLessThan50000(string[] args)
    {
        Assert.Throws<ArgumentException>(() => new CreditArgumentParser(args));
    }



    [Theory]
    [InlineData("0")]
    [InlineData("-1")]
    [InlineData("30")]
    public void CannotCreateCreditForLessThan9Years(string months)
    {
        Assert.Throws<ArgumentException>(() => new CreditArgumentParser(new string[] { "100000", months, "1.3" }));
    }
    
    [Theory]
    [InlineData("301")]
    [InlineData("400")]
    [InlineData("360")]
    public void CannotCreateCreditForMoreThan25Years(string months)
    {
        Assert.Throws<ArgumentException>(() => new CreditArgumentParser(new string[] { "100000", months, "1.3" }));
    }

    [Fact]
    public void UsageFunctionReturnTheRightString()
    {
        string expected = "Usage: CreditImmo <amount> <years> <rate>";
        
        CreditArgumentParser parser = new CreditArgumentParser(new string[] { "100000", "120", "1.3" });
        
        Assert.Equal(expected, parser.Usage());
    }
    
    public static IEnumerable CorrectStringArgs =>
        new List<string[][]>
        {
            new[] { new[] { "100000", "120", "1,2" } },
            new[] { new[] { "200000", "240", "1,4" } },
            new[] { new[] { "1900000", "300", "0" } },
        };
    
    [Theory]
    [MemberData(nameof(CorrectStringArgs))]
    public void CreateCreditWithCorrectArgs(string[] args)
    {
        CreditArgumentParser parser = new CreditArgumentParser(args);
        
        Assert.Equal(double.Parse(args[0]), parser.Create().Amount);
        Assert.Equal(int.Parse(args[1]), parser.Create().Duration);
        Assert.Equal(double.Parse(args[2]), parser.Create().Rate);
    }
}