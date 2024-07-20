using MortgageCalculator;
using MortgageCalculator.Library;
using MortgageCalculator.Library.Models;
using MortgageCalculator.Services;
using static MortgageCalculator.Enums.OutputTypes;


TextMessages.WelcomeScreen();
QuestionnaireModel answers = TextMessages.Questionnaire();

decimal monthlyPayment = Calculations.MonthlyPayment(answers.Principal, answers.Interest, answers.Duration, true);
decimal totalPayment = Calculations.TotalPayment(monthlyPayment, answers.Duration, true);
Console.WriteLine();
Console.WriteLine($"Principal: { answers.Principal }");
Console.WriteLine($"Monthly Payment: { monthlyPayment }");
Console.WriteLine($"Total Payment: { totalPayment }");
Console.WriteLine($"Total Interest: { Calculations.TotalInterest(totalPayment, answers.Principal, true) }");

List<MortgagePaymentModel> results = Calculations.MortgageCalculations(answers);
OutputServices.WriteResults(Output.Console, results);
//WriteResults(Output.TextFile, results);
//WriteResults(Output.CsvFile, results);
Console.ReadLine();

