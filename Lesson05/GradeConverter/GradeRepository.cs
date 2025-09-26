using MySql.Data.MySqlClient;

namespace GradeConverter;

public class GradeRepository(string connectionString) : IGradeRepository
{
    public string GetConvertedGrade(string grade, string currCountry, string conversionCountry)
    {
        using var connection = new MySqlConnection(connectionString);

        connection.Open();

        var query = $"SELECT {conversionCountry} FROM grades WHERE {currCountry} = @grade";

        using var command = new MySqlCommand(query, connection);

        // Using parameters prevents SQL injection
        command.Parameters.AddWithValue("@grade", grade);

        var result = command.ExecuteScalar();
        return result?.ToString() ?? "Grade not found";
    }
}