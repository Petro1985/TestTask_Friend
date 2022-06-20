using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository;

public class UserRepository : IUserRepository
{
    private readonly FriendContext _dbContext;

    public UserRepository(FriendContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserEntity?> GetById(int id)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
    }

    public async Task<UserEntity?> GetByLogin(string login)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(user => user.Login == login);
    }

    public async Task<int> Set(UserEntity user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        return user.Id;
    }
}