using MortgageCalculator.Library.Services;

namespace MortgageCalculator.Library.Tests.Services;

public class CalculationTests
{
    [Theory]
    [InlineData(146787, 10, 14678.70)]
    public void MaxRepayPerYear_IsValid(decimal principal, decimal maxRepayPerYear, decimal expected)
    {
        //Arrange
        //Act
        decimal actual = Calculation.MaxRepayPerYear(principal, maxRepayPerYear);
        //Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(709.27, 360, 255337.2)]
    public void TotalPayment_IsValid(decimal monthlyPayment, int duration, decimal expected) 
    {
        decimal actual = Calculation.TotalPayment(monthlyPayment, duration);
        Assert.Equal(expected, actual);
    }
}
