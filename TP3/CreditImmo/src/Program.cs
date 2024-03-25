using System;
using CreditImmo.Controllers;
using CreditImmo.Models;

namespace CreditImmo
{
    class Program
    {
        static void Main(string[] args)
        {
            CreditArgumentParser argumentParser = new CreditArgumentParser(args);
            
            Credit credit = argumentParser.Create();
            
            CreditController creditController = new CreditController(credit);
            
            creditController.CalculatePayments();
            
            string[] header = { "Number", "AmountToPay", "AmountPaid" };
            
            CsvSerializer csvSerializer = new CsvSerializer("./credit.csv", header);
            
            credit.Serialize(csvSerializer);
        }
    }
}