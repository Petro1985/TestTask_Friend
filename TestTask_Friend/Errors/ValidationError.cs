using TestTask_Friend.Utils;

namespace TestTask_Friend.Errors;

public class ValidationError : IError
{
    public int Code { get; } = 1;
    public string Error { get; } 

    public ValidationError(ValidationResult validationResult)
    {
        Error = "Validation failed \n"+string.Join('\n',validationResult.GetErrors()); 
    }

    public ValidationError()
    {
        Error = "";
    }
}