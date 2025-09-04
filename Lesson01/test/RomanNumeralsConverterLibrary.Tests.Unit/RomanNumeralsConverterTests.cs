using FluentAssertions;

namespace RomanNumeralsConverterLibrary.Tests.Unit;

public class RomanNumeralsConverterTests
{
    // Arrange
    private readonly RomanNumeralsConverter _sut = new();

    [Theory]
    [InlineData("I", 1)]
    [InlineData("V", 5)]
    [InlineData("X", 10)]
    [InlineData("L", 50)]
    [InlineData("C", 100)]
    [InlineData("D", 500)]
    [InlineData("M", 1000)]
    public void ConvertToDecimal_ShouldReturnExpectedValue_WhenGivenValidSingleNumeral(string romanNumeral,
        int expected)
    {
        // Act
        var result = _sut.ConvertToDecimal(romanNumeral);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("II", 2)]
    [InlineData("VI", 6)]
    [InlineData("XII", 12)]
    public void ConvertToDecimal_ShouldReturnExpectedValue_WhenGivenValidAdditiveNumeral(string romanNumeral,
        int expected)
    {
        // Act
        var result = _sut.ConvertToDecimal(romanNumeral);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("IV", 4)]
    [InlineData("IX", 9)]
    [InlineData("XL", 40)]
    [InlineData("XC", 90)]
    [InlineData("CD", 400)]
    [InlineData("CM", 900)]
    [InlineData("XCIV", 94)]
    public void ConvertToDecimal_ShouldReturnExpectedValue_WhenGivenValidSubtractiveNumeral(string romanNumeral,
        int expected)
    {
        // Act
        var result = _sut.ConvertToDecimal(romanNumeral);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("MCMXC", 1990)]
    [InlineData("MDCCCLXVII", 1867)]
    public void ConvertToDecimal_ShouldReturnExpectedValue_WhenGivenValidComplexNumeral(string romanNumeral,
        int expected)
    {
        // Act
        var result = _sut.ConvertToDecimal(romanNumeral);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("MMMCMXCIX", 3999)]
    public void ConvertToDecimal_ShouldReturnExpectedValue_WhenGivenMaximumValue(string romanNumeral, int expected)
    {
        // Act
        var result = _sut.ConvertToDecimal(romanNumeral);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("MMMCMXCIXI")]
    public void ConvertToDecimal_ShouldThrowArgumentException_WhenGivenValueExceedingMaximum(string romanNumeral)
    {
        // Act & Assert
        // var exception = Assert.Throws<ArgumentException>(() => _sut.ConvertToDecimal(romanNumeral));
        // Assert.Contains("exceeds maximum", exception.Message);

        // Act
        Action result = () => _sut.ConvertToDecimal(romanNumeral);

        //Assert
        result.Should()
            .Throw<ArgumentException>()
            .WithMessage("Roman numeral exceeds maximum value of 3999");
    }

    [Theory]
    [InlineData("ii", 2)]
    [InlineData("vi", 6)]
    [InlineData("xii", 12)]
    public void ConvertToDecimal_ShouldHandleCaseInsensitivity_WhenGivenLowercaseInput(string romanNumeral,
        int expected)
    {
        // Act
        var result = _sut.ConvertToDecimal(romanNumeral);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void ConvertToDecimal_ShouldThrowArgumentException_WhenGivenNullOrEmptyInput(string? romanNumeral)
    {
        // Act & Assert
        // var exception = Assert.Throws<ArgumentException>(() => _sut.ConvertToDecimal(romanNumeral));
        // Assert.Contains("null", exception.Message);

        // Act
        Action result = () => _sut.ConvertToDecimal(romanNumeral);

        //Assert
        result.Should()
            .Throw<ArgumentException>()
            .WithMessage("Roman numeral cannot be null or empty");
    }


    [Theory]
    [InlineData("123")]
    [InlineData("abc")]
    public void ConvertToDecimal_ShouldThrowArgumentException_WhenGivenInvalidInput(string romanNumeral)
    {
        // Act & Assert
        // var exception = Assert.Throws<ArgumentException>(() => _sut.ConvertToDecimal(romanNumeral));
        // Assert.Contains("Invalid", exception.Message);

        // Act
        Action result = () => _sut.ConvertToDecimal(romanNumeral);

        //Assert
        result.Should()
            .Throw<ArgumentException>()
            .Where(ex => ex.Message.Contains("Invalid Roman numeral character:"));
    }

    [Theory]
    [InlineData("IIII")]
    [InlineData("XXXX")]
    [InlineData("VV")]
    [InlineData("LL")]
    [InlineData("DD")]
    public void ConvertToDecimal_ShouldThrowArgumentException_WhenGivenTooManyConsecutiveNumerals(string romanNumeral)
    {
        // Act & Assert
        // var exception = Assert.Throws<ArgumentException>(() => _sut.ConvertToDecimal(romanNumeral));
        // Assert.Contains("repeated", exception.Message);

        // Act
        Action result = () => _sut.ConvertToDecimal(romanNumeral);

        //Assert
        result.Should()
            .Throw<ArgumentException>()
            .Where(ex => ex.Message.Contains("cannot be repeated"));
    }

    [Theory]
    [InlineData("IL")]
    [InlineData("IC")]
    [InlineData("ID")]
    [InlineData("XM")]
    public void ConvertToDecimal_ShouldThrowArgumentException_WhenGivenInvalidSubtractiveNumerals(string romanNumeral)
    {
        // Act & Assert
        // var exception = Assert.Throws<ArgumentException>(() => _sut.ConvertToDecimal(romanNumeral));
        // Assert.Contains("subtractive", exception.Message);

        // Act
        Action result = () => _sut.ConvertToDecimal(romanNumeral);

        //Assert
        result.Should()
            .Throw<ArgumentException>()
            .Where(ex => ex.Message.Contains("subtractive"));
    }
}