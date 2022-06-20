using TestTask_Friend.Utils;

namespace TestTask_Friend.Validators;

public interface IValidator<T>
{
    public ValidationResult Validate(T entity);
}