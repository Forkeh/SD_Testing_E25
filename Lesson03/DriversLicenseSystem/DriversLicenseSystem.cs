namespace DriversLicenseSystem;

public class DriversLicenseSystem
{
    public (bool LicenseGranted,
        bool RepeatTheoryExam,
        bool RepeatPracticalExam,
        bool ExtraDrivingLessons) TestResult(int points, int errors)
    {
        var passedTheory = points >= 85;
        var passedPractical = errors <= 2;

        // License granted
        if (passedTheory && passedPractical)
        {
            return (true, false, false, false);
        }

        // Theory retake only
        if (!passedTheory && passedPractical)
        {
            return (false, true, false, false);
        }

        // Practical retake only
        if (passedTheory && !passedPractical)
        {
            return (false, false, true, false);
        }

        // Both retakes + lessons
        return (false, true, true, true);
    }
}