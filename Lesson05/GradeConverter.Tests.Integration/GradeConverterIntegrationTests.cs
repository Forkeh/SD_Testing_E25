using FluentAssertions;
using MySql.Data.MySqlClient;

namespace GradeConverter.Tests.Integration;

public class GradeConverterIntegrationTests
{
    private const string ConnectionString = "Server=localhost;Database=converter-db;Uid=root;Pwd=password;";


    [Theory]
    [InlineData("12", "cDenmark", "A+")]
    [InlineData("10", "cDenmark", "A")]
    [InlineData("7", "cDenmark", "B")]
    [InlineData("4", "cDenmark", "C")]
    [InlineData("02", "cDenmark", "D")]
    [InlineData("00", "cDenmark", "F")]
    [InlineData("-3", "cDenmark", "F")]
    [InlineData("A+", "cUSA", "12")]
    [InlineData("F", "cUSA", "00")]
    public void Convert_Should_ReturnCorrectGrade_When_ValidGradeAndCountry(
        string inputGrade, string fromCountry, string expectedGrade)
    {
        // Arrange
        var repository = new GradeRepository(ConnectionString);
        var converter = new GradeConverter(repository);

        // Act
        var result = converter.Convert(inputGrade, fromCountry);

        // Assert
        result.Should().Be(expectedGrade);
    }

    [Theory]
    [InlineData("", "cDenmark")]
    [InlineData("  ", "cDenmark")]
    [InlineData(null, "cDenmark")]
    public void Convert_Should_ThrowArgumentException_When_GradeIsNullOrEmpty(
        string invalidGrade, string country)
    {
        // Arrange
        var repository = new GradeRepository(ConnectionString);
        var converter = new GradeConverter(repository);

        // Act & Assert
        var act = () => converter.Convert(invalidGrade, country);
        act.Should().Throw<ArgumentException>()
            .WithMessage("Grade cannot be null or empty. (Parameter 'grade')");
    }

    [Theory]
    [InlineData("A", "")]
    [InlineData("A", "  ")]
    [InlineData("A", "cFrance")]
    [InlineData("A", null)]
    public void Convert_Should_ThrowArgumentException_When_CountryIsInvalid(
        string grade, string invalidCountry)
    {
        // Arrange
        var repository = new GradeRepository(ConnectionString);
        var converter = new GradeConverter(repository);

        // Act & Assert
        var act = () => converter.Convert(grade, invalidCountry);
        act.Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData("Z", "cDenmark")]
    public void Convert_Should_ReturnGradeNotFound_When_GradeIsNotFound(
        string invalidGrade, string country)
    {
        // Arrange
        var repository = new GradeRepository(ConnectionString);
        var converter = new GradeConverter(repository);

        // Act
        var result = converter.Convert(invalidGrade, country);

        // Assert
        result.Should().Be("Grade not found");
    }

    [Fact]
    public void Convert_Should_RethrowException_When_DatabaseConnectionFails()
    {
        // Arrange
        const string badConnectionString = "Server=nonexistent;Database=test;";
        var repository = new GradeRepository(badConnectionString);
        var converter = new GradeConverter(repository);

        // Act & Assert
        var act = () => converter.Convert("12", "cDenmark");
        act.Should().Throw<MySqlException>();
    }
}