using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TestTask_Friend.Utils;

public class FriendContextFactory : IDesignTimeDbContextFactory<FriendContext>
{

    public FriendContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<FriendContext>();
        
        optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=FriendDataBase;User Id=postgres;");
        
        return new FriendContext(optionsBuilder.Options);
    }
}