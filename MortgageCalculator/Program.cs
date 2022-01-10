using MortgageCalculator.Library;
using MortgageCalculator.Library.Models;
using System;
using System.Collections.Generic;

namespace MortgageCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WelcomeScreen();
            QuestionnaireModel answers = Questionnaire();

            decimal monthlyPayment = Calculations.MonthlyPayment(answers.Principal, answers.Interest, answers.Duration, true);
            decimal totalPayment = Calculations.TotalPayment(monthlyPayment, answers.Duration, true);
            Console.WriteLine();
            Console.WriteLine($"Principal: { answers.Principal }");
            Console.WriteLine($"Monthly Payment: { monthlyPayment }");
            Console.WriteLine($"Total Payment: { totalPayment }");
            Console.WriteLine($"Total Interest: { Calculations.TotalInterest(totalPayment, answers.Principal, true) }");

            List<MortgagePaymentModel> results = Calculations.MortgageCalculations(answers);
            WriteResults(Output.Console, results);
            //WriteResults(Output.TextFile, results);
            //WriteResults(Output.CsvFile, results);
            Console.ReadLine();
        }
        static public void WelcomeScreen()
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
            interestText = interestText.Replace('.',',');
            double.TryParse(interestText, out double interest);

            Console.WriteLine("What is the amount of mortgage? (150000 / 30000 / only numbers)");
            string principalText = Console.ReadLine();
            decimal.TryParse(principalText, out decimal principal);

            return new QuestionnaireModel() { Duration = duration, Interest = interest, Principal = principal };
        }
        static public void WriteResults(Enum output, List<MortgagePaymentModel> results)
        {
            switch (output)
{
                case Output.Console:
                    foreach (var item in results) { Console.WriteLine($"Month: { item.Month } | Starting Balance: { item.StartingBalance } | Interest: { item.Interest } | Monthly Payment: { item.MonthlyPayment } | Principal: { item.Prinicpal } | Ending Balance: { item.EndingBalance } "); }    break;
                default:
                    Console.WriteLine("No output was selected.");
                    break;
            }
        }
        public enum Output { Console, TextFile, CsvFile }
    }
}
