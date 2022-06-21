namespace TestTask_Friend.Errors;

public interface IError
{
    public int Code { get; }
    public string Error { get; }
}

