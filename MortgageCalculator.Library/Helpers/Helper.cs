namespace MortgageCalculator.Library.Helpers;

public static class Helper
{
    public static int CalculateTotalMonths(this int years)
    {
        return years * 12;
    }
    public static decimal FormatDisplayValue(this decimal value)
    {
        return Math.Round(value, 2);
    }
}
