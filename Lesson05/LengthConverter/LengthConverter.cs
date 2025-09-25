namespace LengthConverter;

public class LengthConverter(double length, string measurementSystem)
{
    public double Convert()
    {
        double result;

        switch (measurementSystem.ToLower())
        {
            case "metric":
                result = length * 0.39;
                break;
            case "imperial":
                result = length * 2.54;
                break;
            default:
                throw new ArgumentException("Invalid measurement system");
        }

        return Math.Round(result, 2);
    }
}