using CurrencyConverter;
using DotNetEnv;
using GradeConverter;


// ----- Test the CurrencyConverter class -----

// Env.Load();
//
// var apiKey = Env.GetString("CURRENCY_API");
//
// var currencyRepository = new CurrencyRepository(new HttpClient(), apiKey);
//
// var converter = new CurrencyConverter.CurrencyConverter("DKK", currencyRepository);
//
// try
// {
//     Console.WriteLine("Testing Currency Converter...");
//
//     var result = await converter.Convert(100, "USD");
//     Console.WriteLine($"100 DKK = {result} USD");
//
//     result = await converter.Convert(50, "EUR");
//     Console.WriteLine($"50 DKK = {result} EUR");
// }
// catch (Exception ex)
// {
//     Console.WriteLine($"Error: {ex.Message}");
// }


// ----- Test the GradeConverter class -----

const string connectionString = "Server=localhost;Database=converter-db;Uid=root;Pwd=password;";

var gradeRepository = new GradeRepository(connectionString);

var gradeConverter = new GradeConverter.GradeConverter(gradeRepository);

var result = gradeConverter.Convert("C", "cUSA");

Console.WriteLine($"Grade conversion: {result}");