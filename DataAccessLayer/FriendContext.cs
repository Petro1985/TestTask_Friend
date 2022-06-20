using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer;

public class FriendContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }

    public FriendContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>().HasIndex(prop => prop.Login).IsUnique();
        modelBuilder.Entity<UserEntity>().Property(prop => prop.tg).IsRequired(false);
        modelBuilder.Entity<UserEntity>().Property(prop => prop.Email).IsRequired(false);

        base.OnModelCreating(modelBuilder);
    }
}


