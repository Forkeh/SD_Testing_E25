using FluentAssertions;

namespace AirlineDiscountCalculator.Tests.Unit;

public class AirlineDiscountCalculatorTests
{
    [Theory]
    [InlineData(2, false, false, false, 100)]
    [InlineData(1, false, false, false, 100)]
    [InlineData(0, false, false, false, 100)]
    [InlineData(1, true, true, true, 100)]
    public void CalculateDiscount_ShouldReturn100Percent_WhenAgeIsBelow3(
        int age,
        bool toIndia,
        bool mondayOrFriday,
        bool stayForSixDaysMinimum,
        int expected)
    {
        // Arrange 
        var sut = new AirlineDiscountCalculator();

        // Act
        var result = sut.CalculateDiscount(age, toIndia, mondayOrFriday, stayForSixDaysMinimum);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(3, false, false, false, 40)]
    [InlineData(4, false, false, false, 40)]
    [InlineData(10, false, false, false, 40)]
    [InlineData(16, false, false, false, 40)]
    [InlineData(17, false, false, false, 40)]
    public void CalculateDiscount_ShouldReturn40Percent_WhenAgeIsBetween3And17Without6DayStay(
        int age,
        bool toIndia,
        bool mondayOrFriday,
        bool stayForSixDaysMinimum,
        int expected)
    {
        // Arrange 
        var sut = new AirlineDiscountCalculator();

        // Act
        var result = sut.CalculateDiscount(age, toIndia, mondayOrFriday, stayForSixDaysMinimum);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(3, false, false, true, 50)]
    [InlineData(4, false, false, true, 50)]
    [InlineData(10, false, false, true, 50)]
    [InlineData(16, false, false, true, 50)]
    [InlineData(17, false, false, true, 50)]
    public void CalculateDiscount_ShouldReturn50Percent_WhenAgeIsBetween3And17With6DayStay(
        int age,
        bool toIndia,
        bool mondayOrFriday,
        bool stayForSixDaysMinimum,
        int expected)
    {
        // Arrange 
        var sut = new AirlineDiscountCalculator();

        // Act
        var result = sut.CalculateDiscount(age, toIndia, mondayOrFriday, stayForSixDaysMinimum);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(18, true, false, false, 20)]
    [InlineData(19, true, false, false, 20)]
    [InlineData(50, true, false, false, 20)]
    [InlineData(129, true, false, false, 20)]
    public void CalculateDiscount_ShouldReturn20Percent_WhenAdultToIndiaNotMondayOrFridayWithout6DayStay(
        int age,
        bool toIndia,
        bool mondayOrFriday,
        bool stayForSixDaysMinimum,
        int expected)
    {
        // Arrange 
        var sut = new AirlineDiscountCalculator();

        // Act
        var result = sut.CalculateDiscount(age, toIndia, mondayOrFriday, stayForSixDaysMinimum);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(18, true, false, true, 30)]
    [InlineData(19, true, false, true, 30)]
    [InlineData(50, true, false, true, 30)]
    [InlineData(129, true, false, true, 30)]
    public void CalculateDiscount_ShouldReturn30Percent_WhenAdultToIndiaNotMondayOrFridayWith6DayStay(
        int age,
        bool toIndia,
        bool mondayOrFriday,
        bool stayForSixDaysMinimum,
        int expected)
    {
        // Arrange 
        var sut = new AirlineDiscountCalculator();

        // Act
        var result = sut.CalculateDiscount(age, toIndia, mondayOrFriday, stayForSixDaysMinimum);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(18, true, true, false, 0)]
    [InlineData(19, true, true, false, 0)]
    [InlineData(50, true, true, false, 0)]
    [InlineData(129, true, true, false, 0)]
    public void CalculateDiscount_ShouldReturn0Percent_WhenAdultToIndiaMondayOrFridayWithout6DayStay(
        int age,
        bool toIndia,
        bool mondayOrFriday,
        bool stayForSixDaysMinimum,
        int expected)
    {
        // Arrange 
        var sut = new AirlineDiscountCalculator();

        // Act
        var result = sut.CalculateDiscount(age, toIndia, mondayOrFriday, stayForSixDaysMinimum);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(18, true, true, true, 10)]
    [InlineData(19, true, true, true, 10)]
    [InlineData(50, true, true, true, 10)]
    [InlineData(129, true, true, true, 10)]
    public void CalculateDiscount_ShouldReturn10Percent_WhenAdultToIndiaMondayOrFridayWith6DayStay(
        int age,
        bool toIndia,
        bool mondayOrFriday,
        bool stayForSixDaysMinimum,
        int expected)
    {
        // Arrange 
        var sut = new AirlineDiscountCalculator();

        // Act
        var result = sut.CalculateDiscount(age, toIndia, mondayOrFriday, stayForSixDaysMinimum);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(18, false, true, false, 0)]
    [InlineData(19, false, true, false, 0)]
    [InlineData(50, false, true, false, 0)]
    [InlineData(129, false, true, false, 0)]
    public void CalculateDiscount_ShouldReturn0Percent_WhenAdultToAsiaMondayOrFridayWithout6DayStay(
        int age,
        bool toIndia,
        bool mondayOrFriday,
        bool stayForSixDaysMinimum,
        int expected)
    {
        // Arrange 
        var sut = new AirlineDiscountCalculator();

        // Act
        var result = sut.CalculateDiscount(age, toIndia, mondayOrFriday, stayForSixDaysMinimum);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(18, false, true, true, 10)]
    [InlineData(19, false, true, true, 10)]
    [InlineData(50, false, true, true, 10)]
    [InlineData(129, false, true, true, 10)]
    public void CalculateDiscount_ShouldReturn10Percent_WhenAdultToAsiaMondayOrFridayWith6DayStay(
        int age,
        bool toIndia,
        bool mondayOrFriday,
        bool stayForSixDaysMinimum,
        int expected)
    {
        // Arrange 
        var sut = new AirlineDiscountCalculator();

        // Act
        var result = sut.CalculateDiscount(age, toIndia, mondayOrFriday, stayForSixDaysMinimum);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(18, false, false, false, 25)]
    [InlineData(19, false, false, false, 25)]
    [InlineData(50, false, false, false, 25)]
    [InlineData(129, false, false, false, 25)]
    public void CalculateDiscount_ShouldReturn25Percent_WhenAdultToAsiaNotMondayOrFridayWithout6DayStay(
        int age,
        bool toIndia,
        bool mondayOrFriday,
        bool stayForSixDaysMinimum,
        int expected)
    {
        // Arrange 
        var sut = new AirlineDiscountCalculator();

        // Act
        var result = sut.CalculateDiscount(age, toIndia, mondayOrFriday, stayForSixDaysMinimum);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(18, false, false, true, 35)]
    [InlineData(19, false, false, true, 35)]
    [InlineData(50, false, false, true, 35)]
    [InlineData(129, false, false, true, 35)]
    public void CalculateDiscount_ShouldReturn35Percent_WhenAdultToAsiaNotMondayOrFridayWith6DayStay(
        int age,
        bool toIndia,
        bool mondayOrFriday,
        bool stayForSixDaysMinimum,
        int expected)
    {
        // Arrange 
        var sut = new AirlineDiscountCalculator();

        // Act
        var result = sut.CalculateDiscount(age, toIndia, mondayOrFriday, stayForSixDaysMinimum);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(-1, false, false, false)]
    [InlineData(-2, false, false, false)]
    [InlineData(130, false, false, false)]
    [InlineData(131, false, false, false)]
    public void CalculateDiscount_ShouldThrowArgumentError_WhenAgeIsInvalid(
        int age,
        bool toIndia,
        bool mondayOrFriday,
        bool stayForSixDaysMinimum)
    {
        // Arrange 
        var sut = new AirlineDiscountCalculator();

        // Act
        Action result = () => sut.CalculateDiscount(age, toIndia, mondayOrFriday, stayForSixDaysMinimum);

        // Assert
        result.Should().Throw<ArgumentOutOfRangeException>();
    }
}