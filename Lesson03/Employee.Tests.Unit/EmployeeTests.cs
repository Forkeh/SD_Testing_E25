using FluentAssertions;

namespace Employee.Tests.Unit;

public class EmployeeTests
{
    [Theory]
    [InlineData(1207852011)]
    [InlineData(1234567890)]
    [InlineData(1111111111)]
    public void CprProperty_Should_SetValue_When_ValidCprProvided(int validCpr)
    {
        // Arrange
        var employee = new Employee
        {
            Cpr = validCpr,
            FirstName = "Martin",
            LastName = "Hansen",
            Department = DepartmentsEnum.IT,
            BaseSalary = 35000,
            SetEducationLevel = 2,
            BirthDate = new DateTime(1985, 7, 12),
            EmploymentDate = DateTime.Now - TimeSpan.FromDays(5),
            Country = "Denmark"
        };
        // Act
        var actual = employee.Cpr;

        // Assert
        actual.Should().Be(validCpr);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(123456789)]
    [InlineData(1234578)]
    public void CprProperty_Should_ThrowArgumentException_When_InvalidCprProvided(int invalidCpr)
    {
        // Arrange & Act
        Action employee = () => new Employee
        {
            Cpr = invalidCpr,
            FirstName = "Martin",
            LastName = "Hansen",
            Department = DepartmentsEnum.IT,
            BaseSalary = 35000,
            SetEducationLevel = 2,
            BirthDate = new DateTime(1985, 7, 12),
            EmploymentDate = DateTime.Now - TimeSpan.FromDays(5),
            Country = "Denmark"
        };


        // Assert
        employee.Should()
            .Throw<ArgumentException>()
            .WithMessage("Cpr must be 10 digits");
    }

    [Theory]
    [InlineData("B")]
    [InlineData("Bo")]
    [InlineData("Jeg Er Et Langt - Navn")]
    [InlineData("AlexandrianaStormveilCrestwoo")]
    [InlineData("AlexandrianaStormveilCrestwood")]
    public void FirstNameProperty_Should_SetValue_When_ValidFirstNameProvided(string validFirstName)
    {
        // Arrange
        var employee = new Employee
        {
            Cpr = 1234567890,
            FirstName = validFirstName,
            LastName = "Hansen",
            Department = DepartmentsEnum.IT,
            BaseSalary = 35000,
            SetEducationLevel = 2,
            BirthDate = new DateTime(1985, 7, 12),
            EmploymentDate = DateTime.Now - TimeSpan.FromDays(5),
            Country = "Denmark"
        };
        // Act
        var actual = employee.FirstName;

        // Assert
        actual.Should().Be(validFirstName);
    }

    [Theory]
    [InlineData("")]
    [InlineData("AlexandriannaStormveilCrestwood")]
    [InlineData("AlexandriannaStormveilCrestwoodd")]
    public void FirstNameProperty_Should_ThrowArgumentException_When_InvalidFirstNameLengthProvided(
        string invalidFirstName)
    {
        // Arrange & Act
        Action employee = () => new Employee
        {
            Cpr = 1234567890,
            FirstName = invalidFirstName,
            LastName = "Hansen",
            Department = DepartmentsEnum.IT,
            BaseSalary = 35000,
            SetEducationLevel = 2,
            BirthDate = new DateTime(1985, 7, 12),
            EmploymentDate = DateTime.Now - TimeSpan.FromDays(5),
            Country = "Denmark"
        };


        // Assert
        employee.Should()
            .Throw<ArgumentException>()
            .WithMessage("First name must be between 1 and 30 characters");
    }

    [Theory]
    [InlineData("12")]
    [InlineData("@")]
    [InlineData("{")]
    public void FirstNameProperty_Should_ThrowArgumentException_When_InvalidFirstNameCharactersProvided(
        string invalidFirstName)
    {
        // Arrange & Act
        Action employee = () => new Employee
        {
            Cpr = 1234567890,
            FirstName = invalidFirstName,
            LastName = "Hansen",
            Department = DepartmentsEnum.IT,
            BaseSalary = 35000,
            SetEducationLevel = 2,
            BirthDate = new DateTime(1985, 7, 12),
            EmploymentDate = DateTime.Now - TimeSpan.FromDays(5),
            Country = "Denmark"
        };


        // Assert
        employee.Should()
            .Throw<ArgumentException>()
            .WithMessage("First name must contain only letters, spaces and dashes");
    }

    [Theory]
    [InlineData("B")]
    [InlineData("Bo")]
    [InlineData("Jeg Er Et Langt - Navn")]
    [InlineData("AlexandrianaStormveilCrestwoo")]
    [InlineData("AlexandrianaStormveilCrestwood")]
    public void LastNameProperty_Should_SetValue_When_ValidLastNameProvided(string validLastName)
    {
        // Arrange
        var employee = new Employee
        {
            Cpr = 1234567890,
            FirstName = "Martin",
            LastName = validLastName,
            Department = DepartmentsEnum.IT,
            BaseSalary = 35000,
            SetEducationLevel = 2,
            BirthDate = new DateTime(1985, 7, 12),
            EmploymentDate = DateTime.Now - TimeSpan.FromDays(5),
            Country = "Denmark"
        };
        // Act
        var actual = employee.LastName;

        // Assert
        actual.Should().Be(validLastName);
    }

    [Theory]
    [InlineData("")]
    [InlineData("AlexandriannaStormveilCrestwood")]
    [InlineData("AlexandriannaStormveilCrestwoodd")]
    public void LastNameProperty_Should_ThrowArgumentException_When_InvalidLastNameLengthProvided(
        string invalidLastName)
    {
        // Arrange & Act
        Action employee = () => new Employee
        {
            Cpr = 1234567890,
            FirstName = "Martin",
            LastName = invalidLastName,
            Department = DepartmentsEnum.IT,
            BaseSalary = 35000,
            SetEducationLevel = 2,
            BirthDate = new DateTime(1985, 7, 12),
            EmploymentDate = DateTime.Now - TimeSpan.FromDays(5),
            Country = "Denmark"
        };


        // Assert
        employee.Should()
            .Throw<ArgumentException>()
            .WithMessage("Last name must be between 1 and 30 characters");
    }

    [Theory]
    [InlineData("12")]
    [InlineData("@")]
    [InlineData("{")]
    public void LastNameProperty_Should_ThrowArgumentException_When_InvalidLastNameCharactersProvided(
        string invalidLastName)
    {
        // Arrange & Act
        Action employee = () => new Employee
        {
            Cpr = 1234567890,
            FirstName = "Martin",
            LastName = invalidLastName,
            Department = DepartmentsEnum.IT,
            BaseSalary = 35000,
            SetEducationLevel = 2,
            BirthDate = new DateTime(1985, 7, 12),
            EmploymentDate = DateTime.Now - TimeSpan.FromDays(5),
            Country = "Denmark"
        };


        // Assert
        employee.Should()
            .Throw<ArgumentException>()
            .WithMessage("Last name must contain only letters, spaces and dashes");
    }

    [Theory]
    [InlineData(DepartmentsEnum.IT)]
    [InlineData(DepartmentsEnum.HR)]
    public void DepartmentProperty_Should_SetValue_When_ValidDepartmentProvided(DepartmentsEnum validDepartment)
    {
        // Arrange
        var employee = new Employee
        {
            Cpr = 1234567890,
            FirstName = "Martin",
            LastName = "Hansen",
            Department = validDepartment,
            BaseSalary = 35000,
            SetEducationLevel = 2,
            BirthDate = new DateTime(1985, 7, 12),
            EmploymentDate = DateTime.Now - TimeSpan.FromDays(5),
            Country = "Denmark"
        };
        // Act
        var actual = employee.Department;

        // Assert
        actual.Should().Be(validDepartment);
    }

    [Theory]
    [InlineData((DepartmentsEnum)999)]
    [InlineData((DepartmentsEnum)(-1))]
    public void DepartmentProperty_Should_ThrowArgumentException_When_InvalidDepartmentProvided(
        DepartmentsEnum invalidDepartment)
    {
        // Arrange & Act
        Action employee = () => new Employee
        {
            Cpr = 1234567890,
            FirstName = "Martin",
            LastName = "Hansen",
            Department = invalidDepartment,
            BaseSalary = 35000,
            SetEducationLevel = 2,
            BirthDate = new DateTime(1985, 7, 12),
            EmploymentDate = DateTime.Now - TimeSpan.FromDays(5),
            Country = "Denmark"
        };

        // Assert
        employee.Should()
            .Throw<ArgumentException>()
            .WithMessage("Department must be a valid enum");
    }

    [Theory]
    [InlineData(20000)]
    [InlineData(20001)]
    [InlineData(65000)]
    [InlineData(99999)]
    [InlineData(100000)]
    public void BaseSalaryProperty_Should_SetValue_When_ValidBaseSalaryProvided(int validBaseSalary)
    {
        // Arrange
        var employee = new Employee
        {
            Cpr = 1234567890,
            FirstName = "Martin",
            LastName = "Hansen",
            Department = DepartmentsEnum.IT,
            BaseSalary = validBaseSalary,
            SetEducationLevel = 2,
            BirthDate = new DateTime(1985, 7, 12),
            EmploymentDate = DateTime.Now - TimeSpan.FromDays(5),
            Country = "Denmark"
        };
        // Act
        var actual = employee.BaseSalary;

        // Assert
        actual.Should().Be(validBaseSalary);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(10000)]
    [InlineData(19998)]
    [InlineData(19999)]
    [InlineData(100001)]
    [InlineData(100002)]
    [InlineData(int.MaxValue)]
    public void BaseSalaryProperty_Should_ThrowArgumentException_When_InvalidBaseSalaryProvided(int validBaseSalary)
    {
        // Arrange & Act
        Action employee = () => new Employee
        {
            Cpr = 1234567890,
            FirstName = "Martin",
            LastName = "Hansen",
            Department = DepartmentsEnum.IT,
            BaseSalary = validBaseSalary,
            SetEducationLevel = 2,
            BirthDate = new DateTime(1985, 7, 12),
            EmploymentDate = DateTime.Now - TimeSpan.FromDays(5),
            Country = "Denmark"
        };

        // Assert
        employee.Should()
            .Throw<ArgumentException>()
            .WithMessage("Base salary must be between 20000 and 100000.");
    }

    [Theory]
    [InlineData(0, "None")]
    [InlineData(1, "Primary")]
    [InlineData(2, "Secondary")]
    [InlineData(3, "Tertiary")]
    public void EducationProperty_Should_SetValue_When_ValidEducationLevelProvided(int validEducationLevel,
        string expectedEducationLevel)
    {
        // Arrange
        var employee = new Employee
        {
            Cpr = 1234567890,
            FirstName = "Martin",
            LastName = "Hansen",
            Department = DepartmentsEnum.IT,
            BaseSalary = 35000,
            SetEducationLevel = validEducationLevel,
            BirthDate = new DateTime(1985, 7, 12),
            EmploymentDate = DateTime.Now - TimeSpan.FromDays(5),
            Country = "Denmark"
        };
        // Act
        var actual = employee.GetEducationLevel;

        // Assert
        actual.Should().Be(expectedEducationLevel);
    }

    [Theory]
    [InlineData(-2)]
    [InlineData(-1)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(99)]
    public void EducationProperty_Should_ThrowArgumentException_When_InvalidEducationLevelProvided(
        int invalidEducationLevel)
    {
        // Arrange & Act
        Action employee = () => new Employee
        {
            Cpr = 1234567890,
            FirstName = "Martin",
            LastName = "Hansen",
            Department = DepartmentsEnum.IT,
            BaseSalary = 35000,
            SetEducationLevel = invalidEducationLevel,
            BirthDate = new DateTime(1985, 7, 12),
            EmploymentDate = DateTime.Now - TimeSpan.FromDays(5),
            Country = "Denmark"
        };


        // Assert
        employee.Should()
            .Throw<ArgumentException>()
            .WithMessage("Education level must be between 0 and 3.");
    }

    [Theory]
    [MemberData(nameof(EmployeeTestData.ValidAgeBoundaryDates), MemberType = typeof(EmployeeTestData))]
    public void BirthDateProperty_Should_SetValue_When_ValidBirthDateProvided(DateTime validBirthDate)
    {
        // Arrange
        var employee = new Employee
        {
            Cpr = 1234567890,
            FirstName = "Martin",
            LastName = "Hansen",
            Department = DepartmentsEnum.IT,
            BaseSalary = 35000,
            SetEducationLevel = 2,
            BirthDate = validBirthDate,
            EmploymentDate = DateTime.Now - TimeSpan.FromDays(5),
            Country = "Denmark"
        };
        // Act
        var actual = employee.BirthDate;

        // Assert
        actual.Should().Be(validBirthDate);
    }

    [Theory]
    [MemberData(nameof(EmployeeTestData.InvalidAgeBoundaryDates), MemberType = typeof(EmployeeTestData))]
    public void BirthDateProperty_Should_ThrowArgumentException_When_InvalidBirthDateProvided(DateTime invalidBirthDate)
    {
        // Arrange & Act
        Action employee = () => new Employee
        {
            Cpr = 1234567890,
            FirstName = "Martin",
            LastName = "Hansen",
            Department = DepartmentsEnum.IT,
            BaseSalary = 35000,
            SetEducationLevel = 2,
            BirthDate = invalidBirthDate,
            EmploymentDate = DateTime.Now - TimeSpan.FromDays(5),
            Country = "Denmark"
        };

        // Assert
        employee.Should()
            .Throw<ArgumentException>()
            .WithMessage("Employee must be at least 18 years old.");
    }

    [Theory]
    [MemberData(nameof(EmployeeTestData.ValidEmploymentBoundaryDates), MemberType = typeof(EmployeeTestData))]
    public void EmploymentDateProperty_Should_SetValue_When_ValidEmploymentDateProvided(DateTime validEmploymentDate)
    {
        // Arrange
        var employee = new Employee
        {
            Cpr = 1234567890,
            FirstName = "Martin",
            LastName = "Hansen",
            Department = DepartmentsEnum.IT,
            BaseSalary = 35000,
            SetEducationLevel = 2,
            BirthDate = new DateTime(1985, 7, 12),
            EmploymentDate = validEmploymentDate,
            Country = "Denmark"
        };
        // Act
        var actual = employee.EmploymentDate;

        // Assert
        actual.Should().Be(validEmploymentDate);
    }

    [Theory]
    [MemberData(nameof(EmployeeTestData.InvalidEmploymentBoundaryDates), MemberType = typeof(EmployeeTestData))]
    public void EmploymentDateProperty_Should_ThrowArgumentException_When_InvalidEmploymentDateProvided(
        DateTime invalidEmploymentDate)
    {
        // Arrange & Act
        Action employee = () => new Employee
        {
            Cpr = 1234567890,
            FirstName = "Martin",
            LastName = "Hansen",
            Department = DepartmentsEnum.IT,
            BaseSalary = 35000,
            SetEducationLevel = 2,
            BirthDate = new DateTime(1985, 7, 12),
            EmploymentDate = invalidEmploymentDate,
            Country = "Denmark"
        };

        // Assert
        employee.Should()
            .Throw<ArgumentException>()
            .WithMessage("Employment date must be before current date.");
    }

    [Theory]
    [InlineData("Denmark")]
    [InlineData("Sweden")]
    [InlineData("D")]
    public void CountryProperty_Should_SetValue_When_ValidCountryProvided(string validCountry)
    {
        // Arrange
        var employee = new Employee
        {
            Cpr = 1234567890,
            FirstName = "Martin",
            LastName = "Hansen",
            Department = DepartmentsEnum.IT,
            BaseSalary = 35000,
            SetEducationLevel = 2,
            BirthDate = new DateTime(1985, 7, 12),
            EmploymentDate = DateTime.Now - TimeSpan.FromDays(5),
            Country = validCountry
        };
        // Act
        var actual = employee.Country;

        // Assert
        actual.Should().Be(validCountry);
    }

    [Theory]
    [InlineData("")]
    public void CountryProperty_Should_ThrowArgumentException_When_InvalidCountryProvided(
        string invalidCountry)
    {
        // Arrange & Act
        Action employee = () => new Employee
        {
            Cpr = 1234567890,
            FirstName = "Martin",
            LastName = "Hansen",
            Department = DepartmentsEnum.IT,
            BaseSalary = 35000,
            SetEducationLevel = 2,
            BirthDate = new DateTime(1985, 7, 12),
            EmploymentDate = DateTime.Now - TimeSpan.FromDays(5),
            Country = invalidCountry
        };


        // Assert
        employee.Should()
            .Throw<ArgumentException>()
            .WithMessage("Country must contain at least one letter.");
    }

    [Theory]
    [InlineData(20000, 0, 20000)]
    [InlineData(20000, 1, 21220)]
    [InlineData(20000, 2, 22440)]
    [InlineData(20000, 3, 23660)]
    [InlineData(65000, 2, 67440)]
    [InlineData(100000, 0, 100000)]
    [InlineData(100000, 2, 102440)]
    [InlineData(100000, 3, 103660)]
    public void GetSalary_Should_ReturnActualSalary_When_ValidBaseSalaryAndEducationLevelProvided(int baseSalary,
        int educationLevel, int expected)
    {
        // Arrange
        var employee = new Employee
        {
            Cpr = 1234567890,
            FirstName = "Martin",
            LastName = "Hansen",
            Department = DepartmentsEnum.IT,
            BaseSalary = baseSalary,
            SetEducationLevel = educationLevel,
            BirthDate = new DateTime(1985, 7, 12),
            EmploymentDate = DateTime.Now - TimeSpan.FromDays(5),
            Country = "Denmark"
        };
        // Act
        var actualSalary = employee.GetSalary();

        // Assert
        actualSalary.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(EmployeeTestData.EmploymentDiscountDates), MemberType = typeof(EmployeeTestData))]
    public void GetDiscount_Should_ReturnDiscount_When_ValidEmploymentDateProvided(DateTime validEmploymentDate,
        double expected)
    {
        // Arrange
        var employee = new Employee
        {
            Cpr = 1234567890,
            FirstName = "Martin",
            LastName = "Hansen",
            Department = DepartmentsEnum.IT,
            BaseSalary = 35000,
            SetEducationLevel = 2,
            BirthDate = new DateTime(1985, 7, 12),
            EmploymentDate = validEmploymentDate,
            Country = "Denmark"
        };
        // Act
        var actual = employee.GetDiscount();

        // Assert
        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData("DENMARK", 0)]
    [InlineData("NorWAy", 0)]
    [InlineData("sweDEN", 0)]
    [InlineData("ICElaNd", 50)]
    [InlineData("finland", 50)]
    [InlineData("ScotLand", 100)]
    [InlineData("RandomCountry", 100)]
    public void GetShippingCosts_Should_ReturnShippingCostPercentage_When_ValidCountryProvided(string validCountry,
        int expected)
    {
        // Arrange
        var employee = new Employee
        {
            Cpr = 1234567890,
            FirstName = "Martin",
            LastName = "Hansen",
            Department = DepartmentsEnum.IT,
            BaseSalary = 35000,
            SetEducationLevel = 2,
            BirthDate = new DateTime(1985, 7, 12),
            EmploymentDate = DateTime.Now - TimeSpan.FromDays(5),
            Country = validCountry
        };
        // Act
        var actualSalary = employee.GetShippingCosts();

        // Assert
        actualSalary.Should().Be(expected);
    }

    [Theory]
    [InlineData("")]
    public void GetShippingCosts_Should_ThrowArgumentException_When_InvalidCountryProvided(string invalidCountry)
    {
        // Arrange & Act
        Action employee = () => new Employee
        {
            Cpr = 1234567890,
            FirstName = "Martin",
            LastName = "Hansen",
            Department = DepartmentsEnum.IT,
            BaseSalary = 35000,
            SetEducationLevel = 2,
            BirthDate = new DateTime(1985, 7, 12),
            EmploymentDate = DateTime.Now - TimeSpan.FromDays(5),
            Country = invalidCountry
        };


        // Assert
        employee.Should()
            .Throw<ArgumentException>()
            .WithMessage("Country must contain at least one letter.");
    }
}