using DotNetEnv;
using FluentAssertions;

namespace CurrencyConverter.Tests.Integration;

public class CurrencyConverterIntegrationTests
{
    private readonly string _apiKey;

    public CurrencyConverterIntegrationTests()
    {
        Env.Load();

        _apiKey = Env.GetString("CURRENCY_API");
    }

    [Fact]
    public async Task Repository_Should_ReturnValidRate_When_CallingRealAPI()
    {
        // Arrange
        var httpClient = new HttpClient();
        var repository = new CurrencyRepository(httpClient, _apiKey);

        // Act
        var rate = await repository.GetConversionRateAsync("EUR", "USD");

        // Assert - Test the API contract
        rate.Should().BeGreaterThan(0);
        rate.Should().BeLessThan(10);
    }

    [Fact]
    public async Task Convert_Should_ReturnValidConversion_When_CallingRealAPI()
    {
        // Arrange
        var httpClient = new HttpClient();
        var repository = new CurrencyRepository(httpClient, _apiKey);
        var converter = new CurrencyConverter("EUR", repository);

        // Act
        var result = await converter.Convert(100, "USD");

        // Assert - Test behavior, not exact values
        result.Should().BeGreaterThan(0);
        result.Should().NotBe(100); // Should be converted
        result.Should().BeInRange(50, 200); // Reasonable range
    }

    [Fact]
    public async Task GetConversionRate_Should_ThrowException_When_InvalidApiKey()
    {
        // Arrange
        var httpClient = new HttpClient();
        var repository = new CurrencyRepository(httpClient, "invalid-key-123");

        // Act & Assert
        var act = async () => await repository.GetConversionRateAsync("EUR", "USD");
        await act.Should().ThrowAsync<Exception>(); // API will return error response
    }

    [Fact]
    public async Task GetConversionRate_Should_ThrowInvalidOperationException_When_CurrencyIsInvalid()
    {
        // Arrange
        var httpClient = new HttpClient();
        var repository = new CurrencyRepository(httpClient, _apiKey);

        // Act & Assert - Test with invalid currency code
        var act = async () => await repository.GetConversionRateAsync("EUR", "XYZ");
        await act.Should().ThrowAsync<InvalidOperationException>(); // Currency not in response
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public async Task GetConversionRate_Should_ThrowInvalidOperationException_When_ApiKeyIsNullOrEmpty(
        string invalidApiKey)
    {
        // Arrange
        var httpClient = new HttpClient();
        var repository = new CurrencyRepository(httpClient, invalidApiKey);

        // Act & Assert
        var act = async () => await repository.GetConversionRateAsync("EUR", "XYZ");
        await act.Should().ThrowAsync<InvalidOperationException>();
    }
}