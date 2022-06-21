namespace TestTask_Friend.Errors;

public class AuthenticationError : IError
{
    public int Code { get; } = 4;
    public string Error { get; } = "Incorrect login or password";
}