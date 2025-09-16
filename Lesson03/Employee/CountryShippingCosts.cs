namespace Employee;

public static class CountryShippingCosts
{
    public static readonly Dictionary<string, int> Dic = new()
    {
        { "denmark", 0 },
        { "norway", 0 },
        { "sweden", 0 },
        { "iceland", 50 },
        { "finland", 50 }
    };
}