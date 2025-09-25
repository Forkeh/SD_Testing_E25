namespace WeightConverter;

public class WeightConverter(double weight, string measurementSystem)
{
    public double Convert()
    {
        double result;

        switch (measurementSystem.ToLower())
        {
            case "metric":
                result = weight * 0.45;
                break;
            case "imperial":
                result = weight * 2.20;
                break;
            default:
                throw new ArgumentException("Invalid measurement system");
        }

        return Math.Round(result, 2);
    }
}