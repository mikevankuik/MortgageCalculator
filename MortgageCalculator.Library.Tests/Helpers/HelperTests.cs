using MortgageCalculator.Library.Helpers;

namespace MortgageCalculator.Library.Tests.Helpers;

public class HelperTests
{
    [Theory]
    [InlineData(15, 180)]
    [InlineData(30, 360)]
    public void CalculateTotalMonths_IsValid(int years, int expected)
    {
        //Arrange
        //Act
        int actual = Helper.CalculateTotalMonths(years);
        //Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1.551, 1.55)]
    [InlineData(1.555, 1.56)]
    [InlineData(1.556, 1.56)]
    public void FormatDisplayValue_IsValid(decimal value, decimal expected)
    {
        decimal actual = Helper.FormatDisplayValue(value);
        Assert.Equal(expected, actual);
    }
}
