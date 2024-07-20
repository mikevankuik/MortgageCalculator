using MortgageCalculator.Library.Services;

namespace MortgageCalculator.Library.Tests.Services;

public class CalculationTests
{
    [Theory]
    [InlineData(146787, 10, 14678.70)]
    public void MaxRepayPerYear_IsValid(decimal principal, double maxRepayPerYear, decimal expected)
    {
        //Arrange
        //Act
        decimal actual = Calculation.MaxRepayPerYear(principal, maxRepayPerYear, true);
        //Assert
        Assert.Equal(expected, actual);
    }
}
