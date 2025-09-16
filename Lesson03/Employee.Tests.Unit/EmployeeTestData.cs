namespace Employee.Tests.Unit;

public class EmployeeTestData
{
    public static IEnumerable<object[]> ValidAgeBoundaryDates
    {
        get
        {
            var today = DateTime.Today;

            yield return [today.AddYears(-18)]; // Exactly 18 today
            yield return [today.AddYears(-18).AddDays(-1)]; // 18 years and 1 day
            yield return [today.AddYears(-25)]; // Well over 18
            yield return [today.AddYears(-100)]; // Very old
            yield return [DateTime.MinValue]; // Extreme past date
        }
    }

    public static IEnumerable<object[]> InvalidAgeBoundaryDates
    {
        get
        {
            var today = DateTime.Today;

            yield return [today.AddYears(-17)]; // Exactly 17 today 
            yield return [today.AddYears(-17).AddDays(-364)]; // 17 years and 364 days
            yield return [today.AddYears(-18).AddDays(1)]; // 18 tomorrow (still 17 today)
            yield return [today.AddYears(-10)]; // Well under 18
            yield return [today.AddYears(1)]; // Well under 18
            yield return [today]; // Born today
            yield return [today.AddDays(1)]; // Born tomorrow
            yield return [today.AddYears(10)]; // Born in future
            yield return [DateTime.MaxValue]; // Extreme future date
        }
    }

    public static IEnumerable<object[]> ValidEmploymentBoundaryDates
    {
        get
        {
            var today = DateTime.Today;

            yield return [today];
            yield return [today.AddDays(-1)];
            yield return [DateTime.MinValue];
        }
    }

    public static IEnumerable<object[]> InvalidEmploymentBoundaryDates
    {
        get
        {
            var today = DateTime.Today;

            yield return [today.AddDays(1)];
            yield return [today.AddDays(2)];
            yield return [DateTime.MaxValue];
        }
    }

    public static IEnumerable<object[]> EmploymentDiscountDates
    {
        get
        {
            var currentYear = DateTime.Now.Year;

            yield return [new DateTime(currentYear, 3, 15), 0.0]; // 0 Year ago
            yield return [new DateTime(currentYear - 1, 3, 14), 0.5]; // 1 year ago
            yield return [new DateTime(currentYear - 1, 3, 15), 0.5]; // 1 year ago
            yield return [new DateTime(currentYear - 1, 3, 16), 0.5]; // 1 year ago
            yield return [new DateTime(currentYear - 2, 3, 15), 1.0]; // 2 years ago  
            yield return [new DateTime(currentYear - 5, 3, 15), 2.5]; // 5 years ago
            yield return [new DateTime(currentYear - 10, 3, 15), 5.0]; // 10 years ago
            yield return [new DateTime(currentYear - 20, 3, 15), 10.0]; // 20 years ago
            yield return [new DateTime(currentYear - 45, 3, 15), 22.5]; // 45 years ago
        }
    }
}