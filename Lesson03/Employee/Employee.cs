using System.Text.RegularExpressions;

namespace Employee;

public partial class Employee
{
    private int _baseSalary;
    private DateTime _birthDate;
    private string? _country;
    private int _cpr;
    private DepartmentsEnum _department;
    private int _educationLevel;
    private DateTime _employmentDate;
    private string? _firstName;
    private string? _lastName;

    public required int Cpr
    {
        get => _cpr;

        set
        {
            if (CountCprDigits(value) != 10)
            {
                throw new ArgumentException("Cpr must be 10 digits");
            }

            _cpr = value;
        }
    }

    public required string FirstName
    {
        get => _firstName;

        set
        {
            if (value.Length is < 1 or > 30)
            {
                throw new ArgumentException("First name must be between 1 and 30 characters");
            }

            if (!NameRegex().IsMatch(value))
            {
                throw new ArgumentException("First name must contain only letters, spaces and dashes");
            }

            _firstName = value;
        }
    }

    public required string LastName
    {
        get => _lastName;

        set
        {
            if (value.Length is < 1 or > 30)
            {
                throw new ArgumentException("Last name must be between 1 and 30 characters");
            }

            if (!NameRegex().IsMatch(value))
            {
                throw new ArgumentException("Last name must contain only letters, spaces and dashes");
            }

            _lastName = value;
        }
    }

    public required DepartmentsEnum Department
    {
        get => _department;

        set
        {
            if (!Enum.IsDefined(typeof(DepartmentsEnum), value))
            {
                throw new ArgumentException("Department must be a valid enum");
            }

            _department = value;
        }
    }

    public required int BaseSalary
    {
        get => _baseSalary;

        set
        {
            if (value is < 20000 or > 100000)
            {
                throw new ArgumentException("Base salary must be between 20000 and 100000.");
            }

            _baseSalary = value;
        }
    }

    public required int SetEducationLevel
    {
        set
        {
            if (value is < 0 or > 3)
            {
                throw new ArgumentException("Education level must be between 0 and 3.");
            }

            _educationLevel = value;
        }
    }

    public string GetEducationLevel => EducationLevels.Dic[_educationLevel];

    public required DateTime BirthDate
    {
        get => _birthDate;

        set
        {
            var age = DateTime.Now.Year - value.Year;
            if (DateTime.Now.DayOfYear < value.DayOfYear)
            {
                age--;
            }

            if (age < 18)
            {
                throw new ArgumentException("Employee must be at least 18 years old.");
            }

            _birthDate = value;
        }
    }

    public required DateTime EmploymentDate
    {
        get => _employmentDate;

        set
        {
            if (value.Date > DateTime.Now.Date)
            {
                throw new ArgumentException("Employment date must be before current date.");
            }

            _employmentDate = value;
        }
    }

    public required string Country
    {
        get => _country;


        set
        {
            if (value.Length < 1)
            {
                throw new ArgumentException("Country must contain at least one letter.");
            }

            _country = value;
        }
    }

    public int GetSalary()
    {
        return BaseSalary + _educationLevel * 1220;
    }

    public double GetDiscount()
    {
        var yearsOfEmployment = DateTime.Now.Year - EmploymentDate.Year;
        if (DateTime.Now.DayOfYear < EmploymentDate.DayOfYear)
        {
            yearsOfEmployment--;
        }

        return yearsOfEmployment * 0.5;
    }

    public int GetShippingCosts()
    {
        return CountryShippingCosts.Dic.GetValueOrDefault(Country.ToLower(), 100);
    }


    private int CountCprDigits(int number)
    {
        return (int)Math.Floor(Math.Log10(number) + 1);
    }

    [GeneratedRegex("^[a-zA-Z\\s-]+$")]
    private static partial Regex NameRegex();
}