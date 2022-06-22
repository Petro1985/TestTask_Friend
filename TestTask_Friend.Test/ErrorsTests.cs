using System.Reflection;
using FluentAssertions;
using TestTask_Friend.Errors;
using Xunit;

namespace TestTask_Friend.Test;

public class ErrorsTests
{
    [Fact]
    public void Errors_Have_Unique_Code()
    {

        var errorCodes = Assembly.GetAssembly(typeof(IError))!.GetTypes()
            .Where(type => type.IsAssignableTo(typeof(IError)) && type.IsAbstract == false)
            .Select(x => ((IError)Activator.CreateInstance(x)!).Code);

        errorCodes.Should().OnlyHaveUniqueItems();
    }
}