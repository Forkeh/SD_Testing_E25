namespace TemperatureConverter;

public class TemperatureConverter(double temperature, string scale)
{
    public double Convert(string toScale)
    {
        double result;

        switch (scale)
        {
            case "C" when toScale == "F":
                result = CelsiusToFahrenheit(temperature);
                break;
            case "C" when toScale == "K":
                result = CelsiusToKelvin(temperature);
                break;
            case "F" when toScale == "C":
                result = FahrenheitToCelsius(temperature);
                break;
            case "F" when toScale == "K":
                result = FahrenheitToKelvin(temperature);
                break;
            case "K" when toScale == "C":
                result = KelvinToCelsius(temperature);
                break;
            case "K" when toScale == "F":
                result = KelvinToFahrenheit(temperature);
                break;
            default: throw new ArgumentException($"{scale} is not a valid measurement scale");
        }

        return Math.Round(result, 2);
    }


    private double CelsiusToFahrenheit(double celsius)
    {
        return celsius * 9.0 / 5.0 + 32;
    }

    private double CelsiusToKelvin(double celsius)
    {
        return celsius + 273.15;
    }

    private double FahrenheitToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5.0 / 9.0;
    }

    private double FahrenheitToKelvin(double fahrenheit)
    {
        return (fahrenheit - 32) * 5.0 / 9.0 + 273.15;
    }

    private double KelvinToCelsius(double kelvin)
    {
        return kelvin - 273.15;
    }

    private double KelvinToFahrenheit(double kelvin)
    {
        return (kelvin - 273.15) * 9.0 / 5.0 + 32;
    }
}