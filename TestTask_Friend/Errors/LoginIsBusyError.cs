namespace TestTask_Friend.Errors;

public class LoginIsBusyError : IError
{
    public int Code { get; } = 3;
    public string Error { get; }

    public LoginIsBusyError(string login)
    {
        Error = $"User with login={login} already exist";
    }

    public LoginIsBusyError()
    {
        Error = "";
    }
}