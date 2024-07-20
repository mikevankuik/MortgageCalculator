namespace MortgageCalculator.Library.Helpers;

public static class Helper
{
    public static int CalculateTotalMonths(this int years)
    {
        return years * 12;
    }
}
