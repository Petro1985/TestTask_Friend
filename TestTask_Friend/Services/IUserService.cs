using DataAccessLayer.Entities;
using TestTask_Friend.APIStruct;
using TestTask_Friend.Utils;

namespace TestTask_Friend.Services;

public interface IUserService
{
    public Task<User?> Get(int id);
    public Task<OperationResult<int, IReadOnlyCollection<string>>> Set(User user);
    Task<OperationResult<UserEntity, string>> Authentication(UserCredentials userCredentials);
}