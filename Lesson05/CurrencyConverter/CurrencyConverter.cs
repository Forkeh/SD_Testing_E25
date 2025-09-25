using System.Text.Json;
using DotNetEnv;

namespace CurrencyConverter;

public class CurrencyConverter(string currency)
{
    private static readonly HttpClient HttpClient = new();
    private readonly string _currency = ValidateCurrency(currency);

    static CurrencyConverter()
    {
        Env.Load();
    }

    private static string ValidateCurrency(string currency)
    {
        if (string.IsNullOrWhiteSpace(currency))
        {
            throw new ArgumentException("Currency cannot be null or empty");
        }

        if (currency.Length != 3)
        {
            throw new ArgumentException("Currency must be exactly 3 characters");
        }

        return currency;
    }

    public async Task<double> Convert(double number, string toCurrency)
    {
        var apiKey = Env.GetString("CURRENCY_API");

        if (string.IsNullOrEmpty(apiKey))
        {
            throw new InvalidOperationException("CURRENCY_API environment variable not found");
        }

        var validatedCurrency = ValidateCurrency(toCurrency);

        var url = new Uri(
            $"https://api.currencyapi.com/v3/latest?apikey={apiKey}&currencies={validatedCurrency}&base_currency={_currency}");

        var result = await HttpClient.GetAsync(url);
        var jsonString = await result.Content.ReadAsStringAsync();

        var apiResponse = JsonSerializer.Deserialize<ApiResponse>(jsonString);

        if (apiResponse == null)
        {
            return -1;
        }

        var conversionRate = apiResponse.Data[toCurrency].Value;

        var convertedCurrency = Math.Round(number * conversionRate, 2);

        return convertedCurrency;
    }
}