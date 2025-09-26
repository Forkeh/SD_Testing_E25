namespace GradeConverter;

public interface IGradeRepository
{
    string GetConvertedGrade(string grade, string currCountry, string conversionCountry);
}