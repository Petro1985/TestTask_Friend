namespace TestTask_Friend.Utils;

public class ValidationResult
{
    private readonly List<string> _errors;

    public ValidationResult()
    {
        _errors = new List<string>();
    }
    
    public static ValidationResult FromCheck(Func<bool> predicate, string errorMessage)
        => FromCheck(predicate.Invoke(), errorMessage);

    public static ValidationResult FromCheck(bool condition, string errorMessage)
    {
        var result = new ValidationResult();
        return result.Check(condition, errorMessage);
    }

    public ValidationResult Check(Func<bool> predicate, string errorMessage)
        => Check(predicate.Invoke(), errorMessage);

    public ValidationResult Check(bool? condition, string errorMessage)
    {
        condition ??= false;
        if (condition == false) AddError(errorMessage);
        return this;
    }

    public IReadOnlyCollection<string> GetErrors()
    {
        return _errors.AsReadOnly();
    }

    public void AddError(string error)
    {
        _errors.Add(error);
    }

    public bool IsError => _errors.Any();

    private ValidationResult(List<string> errors)
    {
        this._errors = errors;
    }

    public ValidationResult CombineWith(ValidationResult other)
    {
        return new ValidationResult(_errors.Concat(other._errors).ToList());
    }
}