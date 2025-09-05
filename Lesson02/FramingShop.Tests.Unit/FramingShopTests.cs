using FluentAssertions;

namespace FramingShop.Tests.Unit;

public class FramingShopTests
{
    // Arrange
    private readonly FramingShop _sut = new();

    [Theory]
    [InlineData(30, 30, 3000)]
    [InlineData(31, 30, 3000)]
    [InlineData(40, 40, 3000)]
    [InlineData(32, 50, 3000)]
    [InlineData(99, 30, 3500)]
    [InlineData(100, 30, 3500)]
    [InlineData(70, 59, 3500)]
    [InlineData(70, 60, 3500)]
    [InlineData(30, 60, 3500)]
    [InlineData(50, 32, 3000)] // area = 1600 exactly (different combination)
    [InlineData(100, 31, 3500)] // just above min height at max width
    [InlineData(99, 59, 3500)] // just below boundaries
    [InlineData(100, 59, 3500)] // max width, just below max height
    public void CalculateFramePrice_ShouldReturnPrice_WhenFrameWidthAndHeightIsValid(int width, int height,
        int expected)
    {
        // Act
        var result = _sut.CalculateFramePrice(width, height);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(0, 40)]
    [InlineData(29, 40)]
    [InlineData(101, 40)]
    [InlineData(70, 0)]
    [InlineData(70, 29)]
    [InlineData(70, 61)]
    [InlineData(29, 29)] // both below minimum
    [InlineData(101, 61)] // both above maximum  
    [InlineData(30, 61)] // valid width, invalid height
    [InlineData(101, 30)] // invalid width, valid height
    public void CalculateFramePrice_ShouldThrowArgumentException_WhenFrameWidthOrHeightIsInvalid(int width, int height)
    {
        // Act
        Action result = () => _sut.CalculateFramePrice(width, height);

        // Assert
        result.Should()
            .Throw<ArgumentException>();
    }
}