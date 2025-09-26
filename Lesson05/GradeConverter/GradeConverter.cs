namespace GradeConverter;

public class GradeConverter(IGradeRepository gradeRepository)
{
    public string Convert(string grade, string currCountry)
    {
        if (string.IsNullOrWhiteSpace(grade))
        {
            throw new ArgumentException("Grade cannot be null or empty.", nameof(grade));
        }

        if (string.IsNullOrWhiteSpace(currCountry))
        {
            throw new ArgumentException("Country cannot be null or empty.", nameof(currCountry));
        }

        if (!IsValidCountry(currCountry))
        {
            throw new ArgumentException("Country is not valid.", nameof(currCountry));
        }

        var conversionCountry = SetConversionCountry(currCountry);

        try
        {
            return gradeRepository.GetConvertedGrade(grade, currCountry, conversionCountry);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
            throw;
        }
    }

    private static bool IsValidCountry(string country)
    {
        return country is "cDenmark" or "cUSA";
    }

    private static string SetConversionCountry(string country)
    {
        country = country switch
        {
            "cDenmark" => "cUSA",
            "cUSA" => "cDenmark",
            _ => throw new ArgumentException("Invalid country, somehow!")
        };

        return country;
    }
}