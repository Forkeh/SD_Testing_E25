namespace CurrencyConverter;

public interface ICurrencyRepository
{
    Task<double> GetConversionRateAsync(string baseCurrency, string toCurrency);
}