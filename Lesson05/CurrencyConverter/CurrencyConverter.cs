namespace CurrencyConverter;

public class CurrencyConverter(string baseCurrency, ICurrencyRepository currencyRepository)
{
    private readonly string _baseCurrency = ValidateCurrency(baseCurrency);


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
        var conversionRate = await currencyRepository.GetConversionRateAsync(_baseCurrency, toCurrency);

        var convertedCurrency = Math.Round(number * conversionRate, 2);

        return convertedCurrency;
    }
}