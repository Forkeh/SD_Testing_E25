namespace Employee;

public static class EducationLevels
{
    public static readonly Dictionary<int, string> Dic = new()
    {
        { 0, "None" },
        { 1, "Primary" },
        { 2, "Secondary" },
        { 3, "Tertiary" }
    };
}