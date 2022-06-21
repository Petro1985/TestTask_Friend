using TestTask_Friend.DAL.Entities;

namespace TestTask_Friend.DAL.Repository;

public interface IUserRepository
{
    public Task<UserEntity?> GetByLogin(string login, CancellationToken cancellationToken);
    public Task<UserEntity?> GetById(int id, CancellationToken cancellationToken);
    public Task<int> Set(UserEntity user, CancellationToken cancellationToken);
    
}