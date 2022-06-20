using System.Text.RegularExpressions;
using TestTask_Friend.APIStruct;
using TestTask_Friend.Utils;

namespace TestTask_Friend.Validators;

public class UserValidator : IValidator<User>
{
    private ValidationResult ValidateEMail(string? email)
    {
        if (String.IsNullOrWhiteSpace(email)) return new ValidationResult();
        const string pattern = @"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])";
        bool regexSuccess = Regex.Match(email??"", pattern, RegexOptions.Compiled).Success;
        return ValidationResult.FromCheck(regexSuccess, "Incorrect EMail");
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
        => ValidationResult.FromCheck(userBirth.AddYears(18) < DateTime.Now, "User must be over 18");

    public ValidationResult Validate(User user)
        => ValidatePassword(user.password)
            .CombineWith(ValidateNotNullProperty(user.name, "Phone"))
            .CombineWith(ValidateNotNullProperty(user.login, "Name"))
            .CombineWith(ValidateNotNullProperty(user.login, "Birth"))
            .CombineWith(ValidateNotNullProperty(user.login, "Login"))
            .CombineWith(ValidateNotNullProperty(user.login, "Password"))
            .CombineWith(ValidateEMail(user.email))
            .CombineWith(ValidateAge(user.birth));

}