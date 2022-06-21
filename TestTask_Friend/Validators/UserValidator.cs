using System.Text.RegularExpressions;
using TestTask_Friend.APIStruct;
using TestTask_Friend.Utils;

namespace TestTask_Friend.Validators;

public class UserValidator : IValidator<UserRequest>
{
    private ValidationResult ValidateEMail(string? email)
    {
        if (email is null) return new ValidationResult();
        const string pattern = @"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])";
        var regexSuccess = Regex.Match(email, pattern, RegexOptions.Compiled).Success;
        var result = ValidationResult.FromCheck(!String.IsNullOrWhiteSpace(email),"Email can't be empty. If you don't want to enter email, use null value");
        return result.Check(regexSuccess, "Incorrect EMail");
    }
    
    private ValidationResult ValidatePassword(string? password)
    {
        var result = ValidationResult
            .FromCheck(
                (password?.Length ?? 0) > 7
                , "Password length is less than 8 symbols")
            .Check(
                password?.Any(Char.IsDigit)
                , "Password must contain at least one digit")
            .Check(
                password is not null && password.Any(Char.IsLower) && password.Any(Char.IsUpper)
                , "Password must contain lower and upper letters");
        
        
        return result;
    }

    private ValidationResult ValidateNotNullProperty(string? name, string propertyName)
        => ValidationResult
            .FromCheck(!String.IsNullOrWhiteSpace(name),
                propertyName + " must be not empty");

    private ValidationResult ValidateAge(DateTime userBirth)
        => ValidationResult.FromCheck(userBirth.AddYears(18) < DateTime.UtcNow, "User must be over 18");

    public ValidationResult Validate(UserRequest user)
        => ValidatePassword(user.Password)
            .CombineWith(ValidateNotNullProperty(user.Name, "Phone"))
            .CombineWith(ValidateNotNullProperty(user.Login, "Name"))
            .CombineWith(ValidateNotNullProperty(user.Login, "Birth"))
            .CombineWith(ValidateNotNullProperty(user.Login, "Login"))
            .CombineWith(ValidateNotNullProperty(user.Login, "Password"))
            .CombineWith(ValidateEMail(user.Email))
            .CombineWith(ValidateAge(user.Birth));

}