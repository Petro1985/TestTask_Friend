using Microsoft.EntityFrameworkCore;
using TestTask_Friend.DAL.Entities;

namespace TestTask_Friend.DAL;

public class FriendContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }

    public FriendContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>().HasIndex(prop => prop.Login).IsUnique();
        modelBuilder.Entity<UserEntity>().Property(prop => prop.Tg).IsRequired(false);
        modelBuilder.Entity<UserEntity>().Property(prop => prop.Email).IsRequired(false);

        base.OnModelCreating(modelBuilder);
    }
}


