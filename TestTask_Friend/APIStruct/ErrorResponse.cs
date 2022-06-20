namespace TestTask_Friend.APIStruct;

public struct ErrorResponse
{
    public int Code { get; init; }
    public string Error { get; init; }

    public ErrorResponse(int code, string error)
    {
        Code = code;
        Error = error;
    }
}