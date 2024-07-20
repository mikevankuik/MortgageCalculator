using MortgageCalculator.Library.Models;

namespace MortgageCalculator.Library;

public static class Calculations
{
     public static decimal MaxRepayPerYear(this decimal principal, double maxRepayPerYear, bool isDisplayValue)
    {

        decimal output = 0;

        output = principal * (decimal)maxRepayPerYear;
        if (isDisplayValue)
        {
            output = Math.Round(output, 2);
        }

        return output;
    }
    public static decimal TotalPayment(decimal monthlyPayment, int duration, bool isDisplayValue)
    {
        decimal output = 0;

        output = monthlyPayment * duration;

        if (isDisplayValue)
        {
            output = Math.Round(output, 2);
        }

        return output;
    }
    public static decimal TotalInterest(decimal totalPayment, decimal principal, bool isDisplayValue)
    {
        decimal output = 0;

        output = totalPayment - principal;

        if (isDisplayValue)
        {
            output = Math.Round(output, 2);
        }

        return output;
    }

    public static decimal MonthlyPayment(decimal principal, double interest, int duration, bool isDisplayValue)
    {
        decimal output = 0;

        double montlyInterestRate = interest.MonthlyInterestRate();
        decimal mortgageMagic = (decimal)(1 - Math.Pow(1 + montlyInterestRate, -duration));

        output = principal * ((decimal)montlyInterestRate) / mortgageMagic;
        if (isDisplayValue)
        {
            output = Math.Round(output, 2);
        }
        return output;
    }
    public static decimal MonthlyInterest(decimal principal, double interest)
    {
        decimal output = 0;

        output = principal * (decimal)MonthlyInterestRate(interest);

        return output;
    }

    public static List<MortgagePaymentModel> MortgageCalculations(QuestionnaireModel answer)
    {
        List<MortgagePaymentModel> output = new();

        decimal monthlyPayment = MonthlyPayment(answer.Principal, answer.Interest, answer.Duration, false);
        decimal totalPayment = TotalPayment(monthlyPayment, answer.Duration, false);
        decimal displayTotalPayment = TotalPayment(monthlyPayment, answer.Duration, true);
        decimal displayMonthlyPayment = MonthlyPayment(answer.Principal, answer.Interest, answer.Duration, true);
        decimal displayTotalInterest = TotalInterest(totalPayment, answer.Principal, true);
        int calculateMonth = 0;
        for (int i = answer.Duration; i > 0; i--)
        {
            calculateMonth++;

            decimal monthlyInterest = MonthlyInterest(answer.Principal, answer.Interest);
            decimal monthlyPrinipalPayment = monthlyPayment - monthlyInterest;
            decimal startingBalance = answer.Principal;
            answer.Principal += monthlyInterest;
            answer.Principal -= monthlyPayment;
            decimal displayStartingBalance = Math.Round(startingBalance, 2);
            displayMonthlyPayment = Math.Round(monthlyPayment, 2);
            decimal endingBalance = Math.Round(answer.Principal, 2);
            decimal displayInterest = Math.Round(monthlyInterest, 2);
            decimal displayMonthlyPrincipal = Math.Round(monthlyPrinipalPayment, 2);
            output.Add(new MortgagePaymentModel
            {
                Month = calculateMonth,
                StartingBalance = displayStartingBalance,
                Interest = displayInterest,
                MonthlyPayment = displayMonthlyPayment,
                Prinicpal = displayMonthlyPrincipal,
                EndingBalance = endingBalance
            });
        }
        return output;
    }


    public static double MonthlyInterestRate(this double interest)
    {
        return interest / 100 / 12;
    }
    public static int CalculateTotalMonths(this int years)
    {
        return years * 12;
    }
}
