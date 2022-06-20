namespace TestTask_Friend.Utils;

public class OperationResult <TResult, TError>
{
    public TResult? Result { get; }
    public bool IsSuccessful { get; }
    public TError? Error { get; }

    public OperationResult(TResult result)
    {
        Result = result;
        IsSuccessful = true;
    }
    public OperationResult(TError error)
    {
        Error = error;
        IsSuccessful = false;
    }
}