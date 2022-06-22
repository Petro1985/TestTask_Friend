using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using TestTask_Friend.DAL;
using TestTask_Friend.DAL.Entities;
using TestTask_Friend.DAL.Repository;
using Xunit;

namespace TestTask_Friend.Test;

public class UserRepositoryTests
{
    private readonly UserRepository _userRepository;
    private readonly FriendContext _context;
    
    public UserRepositoryTests()
    {
        var optBuilder = new DbContextOptionsBuilder<FriendContext>();
        optBuilder.UseSqlite("Data Source=:memory:;");
        _context = new FriendContext(optBuilder.Options);
        _userRepository = new UserRepository(_context);
        
        _context.Database.OpenConnection();
        _context.Database.EnsureCreated();
    }

    [Fact]
    public async Task UserRepository_GetByLogin_Method()
    {
        var expectedUser = new UserEntity
        {
            Id = 1,
            Birth = new DateOnly(1985,1,5),
            Email = "Petro1985@list.ru",
            Login = "Petro",
            Name = "Petr",
            Password = "123qew!@#",
            Phone = "333-333-11-22",
            Tg = "",
        };
        
        await _userRepository.Set(expectedUser);

        var result = await _userRepository.GetByLogin("Petro");

        expectedUser.Should().Be(result);
    }
    
    [Fact]
    public async Task UserRepository_GetById_Method()
    {
        var expectedUser = new UserEntity
        {
            Id = 1,
            Birth = new DateOnly(1985,1,5),
            Email = "Petro1985@list.ru",
            Login = "Petro",
            Name = "Petr",
            Password = "123qew!@#",
            Phone = "333-333-11-22",
            Tg = "",
        };
        
        var id = await _userRepository.Set(expectedUser);

        var result = await _userRepository.GetById(1);

        expectedUser.Should().Be(result);
    }
    
    [Fact]
    public async Task UserRepository_Set_Method()
    {
        var expectedUser = new UserEntity
        {
            Id = 1,
            Birth = new DateOnly(1985,1,5),
            Email = "Petro1985@list.ru",
            Login = "Petro",
            Name = "Petr",
            Password = "123qew!@#",
            Phone = "333-333-11-22",
            Tg = "",
        };
        
        var id = await _userRepository.Set(expectedUser);
        id.Should().BePositive();
    }
}