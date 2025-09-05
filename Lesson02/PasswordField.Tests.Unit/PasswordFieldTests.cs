using FluentAssertions;

namespace PasswordFieldLibrary.Tests.Unit;

public class PasswordFieldTests
{
    // Arrange
    private readonly PasswordField _sut = new();
    
    [Theory]
    [InlineData("123456", "123456")]
    [InlineData("1234567", "1234567")]
    [InlineData("12345678", "12345678")]
    [InlineData("123456789", "123456789")]
    [InlineData("1234567890", "1234567890")]
    public void ValidatePassword_ShouldReturnPassword_WhenPasswordLengthIsValid(string password, string expected)
    {
        // Act
        var result = _sut.ValidatePassword(password);
        
        // Assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("12345")]
    [InlineData("12345678901")]
    public void ValidatePassword_ShouldThrowArgumentException_WhenPasswordLengthIsInvalid(string password)
    {
        // Act
        Action result = () => _sut.ValidatePassword(password);
        
        //Assert
        result.Should()
            .Throw<ArgumentException>();
    }
}