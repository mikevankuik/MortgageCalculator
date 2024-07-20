using MortgageCalculator.Library.Models;
using static MortgageCalculator.Enums.OutputTypes;

namespace MortgageCalculator.Services;

public class OutputServices
{
    public static void WriteResults(Enum output, List<MortgagePaymentModel> results)
    {
        switch (output)
        {
            case Output.Console:
                foreach (var item in results) { Console.WriteLine($"Month: {item.Month} | Starting Balance: {item.StartingBalance} | Interest: {item.Interest} | Monthly Payment: {item.MonthlyPayment} | Principal: {item.Prinicpal} | Ending Balance: {item.EndingBalance} "); }
                break;
            default:
                Console.WriteLine("No output was selected.");
                break;
        }
    }
}
