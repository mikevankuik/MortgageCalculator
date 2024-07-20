using MortgageCalculator.Library.Models;
using MortgageCalculator.Library;

namespace MortgageCalculator;

public class TextMessages
{
    public static void WelcomeScreen()
    {
        var version = "1.0";
        Console.WriteLine($"Welcome to the Mortgage Calcualtor {version}");
        Console.WriteLine($"Created by: Mike van Kuik - 2022");
    }

    static public QuestionnaireModel Questionnaire()
    {
        Console.WriteLine("How long should the mortgage be? (years 5/10/15/30)");
        string durationText = Console.ReadLine();
        int.TryParse(durationText, out int durationNumber);
        int duration = Calculations.CalculateTotalMonths(durationNumber);

        Console.WriteLine("What is the interestrate? (percentage 1 / 4.1)");
        string interestText = Console.ReadLine();
        interestText = interestText.Replace('.', ',');
        double.TryParse(interestText, out double interest);

        Console.WriteLine("What is the amount of mortgage? (150000 / 30000 / only numbers)");
        string principalText = Console.ReadLine();
        decimal.TryParse(principalText, out decimal principal);

        return new QuestionnaireModel() { Duration = duration, Interest = interest, Principal = principal };
    }
}
