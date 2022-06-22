using FluentAssertions;
using TestTask_Friend.APIStruct;
using TestTask_Friend.Validators;
using Xunit;

namespace TestTask_Friend.Test;

public class UserValidationTests
{
    private readonly UserValidator _validator;

    public UserValidationTests()
    {
        _validator = new UserValidator();
    }

    [Fact]
    public void UserValidation_ValidateEMail_Method_Success()
    {
        var user = new UserRequest
        {
            Birth = DateTime.UtcNow.AddYears(-19),
            Email = "Petro1985@list.ru",
            Login = "Petro",
            Name = "Petr",
            Password = "123Qew!@#",
            Phone = "333-333-11-22",
            Tg = "",
        };

        var result = _validator.Validate(user);

        result.IsError.Should().BeFalse();
    }
    
    [Fact]
    public void UserValidation_ValidateEMail_Method_Fail()
    {
        var user = new UserRequest
        {
            Birth = DateTime.UtcNow.AddYears(-19),
            Email = "Petro1985@listru",
            Login = "Petro",
            Name = "Petr",
            Password = "123Qew!@#",
            Phone = "333-333-11-22",
            Tg = "",
        };

        var result = _validator.Validate(user);

        result.IsError.Should().BeTrue();
    }    

    [Fact]
    public void UserValidation_ValidateAge_Method_Success()
    {
        var user = new UserRequest
        {
            Birth = DateTime.UtcNow.AddYears(-19),
            Email = "Petro1985@list.ru",
            Login = "Petro",
            Name = "Petr",
            Password = "123Qew!@#",
            Phone = "333-333-11-22",
            Tg = "",
        };

        var result = _validator.Validate(user);

        result.IsError.Should().BeFalse();
    }    
    
    [Fact]
    public void UserValidation_ValidateAge_Method_Fail()
    {
        var user = new UserRequest
        {
            Birth = DateTime.UtcNow.AddYears(-5),
            Email = "Petro1985@list.ru",
            Login = "Petro",
            Name = "Petr",
            Password = "123Qew!@#",
            Phone = "333-333-11-22",
            Tg = "",
        };

        var result = _validator.Validate(user);

        result.IsError.Should().BeTrue();
    }
    
    [Fact]
    public void UserValidation_ValidateNotNullProperty_Method_Fail()
    {
        var user = new UserRequest
        {
            Birth = DateTime.UtcNow.AddYears(-19),
            Email = "",
            Login = "Petro",
            Name = "Petr",
            Password = "123Qew!@#",
            Phone = "333-333-11-22",
            Tg = "",
        };

        var result = _validator.Validate(user);

        result.IsError.Should().BeTrue();
    }
    
    [Fact]
    public void UserValidation_ValidateNotNullProperty_Method_Success()
    {
        var user = new UserRequest
        {
            Birth = DateTime.UtcNow.AddYears(-19),
            Email = null,
            Login = "Petro",
            Name = "Petr",
            Password = "123Qew!@#",
            Phone = "333-333-11-22",
            Tg = "",
        };

        var result = _validator.Validate(user);

        result.IsError.Should().BeFalse();
    }
    
    [Fact]
    public void UserValidation_ValidatePassword_Method_Fail()
    {
        var user = new UserRequest
        {
            Birth = DateTime.UtcNow.AddYears(-19),
            Email = null,
            Login = "Petro",
            Name = "Petr",
            Password = "q",
            Phone = "333-333-11-22",
            Tg = "",
        };

        var result = _validator.Validate(user);

        result.IsError.Should().BeTrue();
        result.GetErrors().Count().Should().Be(3);
    }
    
    [Fact]
    public void UserValidation_ValidatePassword_Method_Success()
    {
        var user = new UserRequest
        {
            Birth = DateTime.UtcNow.AddYears(-19),
            Email = null,
            Login = "Petro",
            Name = "Petr",
            Password = "123qwe!@#QWE",
            Phone = "333-333-11-22",
            Tg = "",
        };

        var result = _validator.Validate(user);

        result.IsError.Should().BeFalse();
    }
    
}