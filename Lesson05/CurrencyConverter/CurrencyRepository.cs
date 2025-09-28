using System.Text.Json;

namespace CurrencyConverter;

public class CurrencyRepository(HttpClient httpClient, string apiKey) : ICurrencyRepository
{
    public async Task<double> GetConversionRateAsync(string baseCurrency, string toCurrency)
    {
        if (string.IsNullOrEmpty(apiKey))
        {
            throw new InvalidOperationException("CURRENCY_API environment variable not found");
        }


        var url = new Uri(
            $"https://api.currencyapi.com/v3/latest?apikey={apiKey}&currencies={toCurrency}&base_currency={baseCurrency}");

        var result = await httpClient.GetAsync(url);
        var jsonString = await result.Content.ReadAsStringAsync();

        // Check if HTTP request was successful
        if (!result.IsSuccessStatusCode)
        {
            throw new InvalidOperationException(
                $"API request failed with status: {result.StatusCode}. Response: {jsonString}");
        }

        var apiResponse = JsonSerializer.Deserialize<ApiResponse>(jsonString);

        if (apiResponse?.Data == null)
        {
            throw new InvalidOperationException("Invalid API response format");
        }

        return apiResponse.Data[toCurrency].Value;
    }
}