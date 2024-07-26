using MortgageCalculator;
using MortgageCalculator.Library.Models;
using MortgageCalculator.Library.Services;
using MortgageCalculator.Services;
using static MortgageCalculator.Enums.OutputTypes;


TextMessages.WelcomeScreen();
QuestionnaireModel answers = TextMessages.Questionnaire();

decimal monthlyPayment = Calculation.MonthlyPayment(answers.Principal, answers.Interest, answers.Duration, true);
decimal totalPayment = Calculation.TotalPayment(monthlyPayment, answers.Duration);
Console.WriteLine();
Console.WriteLine($"Principal: { answers.Principal }");
Console.WriteLine($"Monthly Payment: { monthlyPayment }");
Console.WriteLine($"Total Payment: { totalPayment }");
Console.WriteLine($"Total Interest: { Calculation.TotalInterest(totalPayment, answers.Principal, true) }");

List<MortgagePaymentModel> results = Calculation.MortgageCalculations(answers);
OutputServices.WriteResults(Output.Console, results);
//WriteResults(Output.TextFile, results);
//WriteResults(Output.CsvFile, results);
Console.ReadLine();

