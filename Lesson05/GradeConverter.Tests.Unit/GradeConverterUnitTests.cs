using FluentAssertions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace GradeConverter.Tests.Unit;

public class GradeConverterUnitTests
{
    [Theory]
    [InlineData("12", "cDenmark", "A+")]
    [InlineData("10", "cDenmark", "A")]
    [InlineData("7", "cDenmark", "B")]
    [InlineData("A+", "cUSA", "12")]
    [InlineData("A", "cUSA", "10")]
    public void Convert_Should_ReturnCorrectGrade_When_ValidInput(
        string inputGrade, string fromCountry, string expectedGrade)
    {
        // Arrange - Mock the repository
        var mockRepository = Substitute.For<IGradeRepository>();
        var conversionCountry = fromCountry == "cDenmark" ? "cUSA" : "cDenmark";

        mockRepository.GetConvertedGrade(inputGrade, fromCountry, conversionCountry)
            .Returns(expectedGrade);

        var converter = new GradeConverter(mockRepository);

        // Act
        var result = converter.Convert(inputGrade, fromCountry);

        // Assert
        result.Should().Be(expectedGrade);
        mockRepository.Received(1).GetConvertedGrade(inputGrade, fromCountry, conversionCountry);
    }

    [Theory]
    [InlineData("", "cDenmark")]
    [InlineData("  ", "cDenmark")]
    [InlineData("12", "")]
    [InlineData("12", " ")]
    public void Convert_Should_ThrowArgumentException_When_GradeOrCountryIsNullOrEmpty(
        string grade, string country)
    {
        // Arrange
        var mockRepository = Substitute.For<IGradeRepository>();
        var converter = new GradeConverter(mockRepository);

        // Act & Assert
        var act = () => converter.Convert(grade, country);
        act.Should().Throw<ArgumentException>()
            .WithMessage("*cannot be null or empty*");

        // Verify repository was never called
        mockRepository.DidNotReceive().GetConvertedGrade(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
    }

    [Theory]
    [InlineData("12", "invalidCountry")]
    public void Convert_Should_ThrowArgumentException_When_CountryIsInvalid(
        string grade, string invalidCountry)
    {
        // Arrange
        var mockRepository = Substitute.For<IGradeRepository>();
        var converter = new GradeConverter(mockRepository);

        // Act & Assert
        var act = () => converter.Convert(grade, invalidCountry);
        act.Should().Throw<ArgumentException>()
            .WithMessage("*Country is not valid*");

        // Verify repository was never called
        mockRepository.DidNotReceive().GetConvertedGrade(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
    }

    [Fact]
    public void Convert_Should_RethrowException_When_RepositoryThrows()
    {
        // Arrange
        var mockRepository = Substitute.For<IGradeRepository>();
        mockRepository.GetConvertedGrade(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>())
            .Throws(new InvalidOperationException("Database connection failed"));

        var converter = new GradeConverter(mockRepository);

        // Act & Assert
        var act = () => converter.Convert("12", "cDenmark");
        act.Should().Throw<InvalidOperationException>()
            .WithMessage("Database connection failed");
    }
}