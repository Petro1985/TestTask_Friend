using TestTask_Friend.APIStruct;
using TestTask_Friend.Utils;

namespace TestTask_Friend.Services;

public interface IUserService
{
    public Task<OperationResult<UserResponse>> Get(int id, CancellationToken cancellationToken = default);
    public Task<OperationResult<int>> Set(UserRequest user, CancellationToken cancellationToken = default);
    public Task<OperationResult<int>> Authentication(UserCredentials userCredentials, CancellationToken cancellationToken = default);
}