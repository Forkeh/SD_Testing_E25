using FluentAssertions;

namespace DriversLicenseSystem.Tests.Unit;

public class DriversLicenseSystemTests
{
    [Theory]
    [InlineData(85, 0, true, false, false, false)]
    [InlineData(86, 0, true, false, false, false)]
    [InlineData(90, 0, true, false, false, false)]
    [InlineData(99, 0, true, false, false, false)]
    [InlineData(100, 0, true, false, false, false)]
    [InlineData(100, 1, true, false, false, false)]
    [InlineData(100, 2, true, false, false, false)]
    [InlineData(85, 2, true, false, false, false)]
    public void TestResult_ShouldGrantLicense_WhenPointsAndErrorsAreAcceptable(
        int points,
        int errors,
        bool expectedLicenseGranted,
        bool expectedRepeatTheoryExam,
        bool expectedRepeatPracticalExam,
        bool expectedExtraDrivingLessons)
    {
        // Arrange
        var sut = new DriversLicenseSystem();

        // Act
        var result = sut.TestResult(points, errors);

        // Assert
        var expected =
            (expectedLicenseGranted,
                expectedRepeatTheoryExam,
                expectedRepeatPracticalExam,
                expectedExtraDrivingLessons);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(0, 0, false, true, false, false)]
    [InlineData(1, 0, false, true, false, false)]
    [InlineData(2, 0, false, true, false, false)]
    [InlineData(44, 0, false, true, false, false)]
    [InlineData(83, 0, false, true, false, false)]
    [InlineData(84, 0, false, true, false, false)]
    public void TestResult_ShouldRequireTheoryRetake_WhenPointsAreTooLow(
        int points,
        int errors,
        bool expectedLicenseGranted,
        bool expectedRepeatTheoryExam,
        bool expectedRepeatPracticalExam,
        bool expectedExtraDrivingLessons)
    {
        // Arrange
        var sut = new DriversLicenseSystem();

        // Act
        var result = sut.TestResult(points, errors);

        // Assert
        var expected =
            (expectedLicenseGranted,
                expectedRepeatTheoryExam,
                expectedRepeatPracticalExam,
                expectedExtraDrivingLessons);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(100, 3, false, false, true, false)]
    [InlineData(100, 4, false, false, true, false)]
    [InlineData(100, 10, false, false, true, false)]
    public void TestResult_ShouldRequirePracticalRetake_WhenErrorsAreTooHigh(
        int points,
        int errors,
        bool expectedLicenseGranted,
        bool expectedRepeatTheoryExam,
        bool expectedRepeatPracticalExam,
        bool expectedExtraDrivingLessons)
    {
        // Arrange
        var sut = new DriversLicenseSystem();

        // Act
        var result = sut.TestResult(points, errors);

        // Assert
        var expected =
            (expectedLicenseGranted,
                expectedRepeatTheoryExam,
                expectedRepeatPracticalExam,
                expectedExtraDrivingLessons);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(0, 3, false, true, true, true)]
    [InlineData(1, 3, false, true, true, true)]
    [InlineData(84, 3, false, true, true, true)]
    [InlineData(83, 3, false, true, true, true)]
    [InlineData(84, 4, false, true, true, true)]
    [InlineData(84, 10, false, true, true, true)]
    public void TestResult_ShouldRequireDrivingLessons_WhenPointsAndErrorsAreUnacceptable(
        int points,
        int errors,
        bool expectedLicenseGranted,
        bool expectedRepeatTheoryExam,
        bool expectedRepeatPracticalExam,
        bool expectedExtraDrivingLessons)
    {
        // Arrange
        var sut = new DriversLicenseSystem();

        // Act
        var result = sut.TestResult(points, errors);

        // Assert
        var expected =
            (expectedLicenseGranted,
                expectedRepeatTheoryExam,
                expectedRepeatPracticalExam,
                expectedExtraDrivingLessons);

        result.Should().Be(expected);
    }
}