namespace PasswordFieldLibrary;

public class PasswordField
{
    public string ValidatePassword(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("Password must not be null or empty");
        }

        return password.Length switch
        {
            < 6 => throw new ArgumentException("Password must have at least 6 characters"),
            > 10 => throw new ArgumentException("Password must have at most 10 characters"),
            _ => password
        };
    }
}