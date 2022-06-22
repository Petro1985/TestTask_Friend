namespace TestTask_Friend.APIStruct;

public class UserCredentials
{
    public UserCredentials(string login, string password)
    {
        Login = login;
        Password = password;
    }

    public string Login { get; }
    public string Password { get; }
}