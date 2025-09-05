using FluentAssertions;

namespace E_ShopLibrary.Tests.Unit;

public class EshopTests
{
    // Arrange
    private readonly EShop _sut = new();

    [Theory]
    [InlineData(0, 0)]
    [InlineData(0.01, 0)]
    [InlineData(150, 0)]
    [InlineData(299.99, 0)]
    [InlineData(300, 0)]
    [InlineData(300.01, 5)]
    [InlineData(600, 5)]
    [InlineData(799.99, 5)]
    [InlineData(800, 5)]
    [InlineData(800.01, 10)]
    [InlineData(1200, 10)]
    [InlineData(999999.99, 10)]
    public void CalculateDiscount_ShouldReturnDiscount_WhenPurchaseAmountIsValid(double purchaseAmount,
        int expected)
    {
        // Act
        var result = _sut.CalculateDiscount(purchaseAmount);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(-0.01)]
    [InlineData(-50)]
    public void CalculateDiscount_ShouldThrowError_WhenPurchaseAmountIsInvalid(double purchaseAmount)
    {
        // Act
        Action result = () => _sut.CalculateDiscount(purchaseAmount);

        // Assert
        result.Should()
            .Throw<ArgumentException>();
    }
}