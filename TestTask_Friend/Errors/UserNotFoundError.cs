namespace TestTask_Friend.Errors;

public class UserNotFoundError : IError
{
    public int Code { get; } = 2;
    public string Error { get; }

    public UserNotFoundError(int userId)
    {
        Error = $"User with id={userId} was not found";
    }

    public UserNotFoundError()
    {
        Error = "";
    }
}