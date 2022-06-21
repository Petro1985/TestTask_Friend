using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using TestTask_Friend.Errors;

namespace TestTask_Friend.Utils;

public class OperationResult <TResult>
{
    public TResult? Result { get; }
    public bool IsSuccessful { get; }
    public IError? Error { get; }

    public OperationResult(TResult result)
    {
        Result = result;
        IsSuccessful = true;
    }
    
    public OperationResult(IError error)
    {
        Error = error;
        IsSuccessful = false;
    }
}

public static class OperationResult
{
    public static IActionResult ToActionResult<T>(this OperationResult<T> operationResult)
    {
        if (operationResult.IsSuccessful) return new OkObjectResult(operationResult.Result);
        return new BadRequestObjectResult(operationResult.Error);
    }
}

