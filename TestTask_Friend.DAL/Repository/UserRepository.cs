using Microsoft.EntityFrameworkCore;
using TestTask_Friend.DAL.Entities;

namespace TestTask_Friend.DAL.Repository;

public class UserRepository : IUserRepository
{
    private readonly FriendContext _dbContext;

    public UserRepository(FriendContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserEntity?> GetById(int id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
    }

    public async Task<UserEntity?> GetByLogin(string login, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(user => user.Login == login, cancellationToken);
    }

    public async Task<int> Set(UserEntity user, CancellationToken cancellationToken = default)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return user.Id;
    }
}