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
}
