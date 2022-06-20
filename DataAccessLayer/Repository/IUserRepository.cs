using DataAccessLayer.Entities;

namespace DataAccessLayer.Repository;

public interface IUserRepository
{
    public Task<UserEntity?> GetByLogin(string login);
    public Task<UserEntity?> GetById(int id);
    public Task<int> Set(UserEntity user);
    
}