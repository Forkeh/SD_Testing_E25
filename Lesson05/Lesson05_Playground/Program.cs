// Test the CurrencyConverter class

var converter = new CurrencyConverter.CurrencyConverter("DKK");

try
{
    Console.WriteLine("Testing Currency Converter...");

    var result = await converter.Convert(100, "USD");
    Console.WriteLine($"100 DKK = {result} USD");

    result = await converter.Convert(50, "EUR");
    Console.WriteLine($"50 DKK = {result} EUR");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

Console.WriteLine("Press any key to exit...");
Console.ReadKey();