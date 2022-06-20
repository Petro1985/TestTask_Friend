using System.Dynamic;
using System.Net;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using TestTask_Friend.APIStruct;
using TestTask_Friend.Services;

namespace TestTask_Friend.Controllers;

[ApiController]
[Route("[controller]")]
public class FriendController : ControllerBase
{
    private readonly ILogger<FriendController> _logger;
    private readonly IUserService _userService;
    
    public FriendController(ILogger<FriendController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpGet("v1/user")]
    public async Task<IActionResult> GetUserInfo([FromQuery] int id)
    {
        var user = await _userService.Get(id);
        if (user is null) return BadRequest(new ErrorResponse(3, $"There is no user with ID={id} in DataBase"));
        return Ok(user);
    }

    [HttpPost("v1/auth/register")]
    public async Task<IActionResult> Registration(User user)
    {
        var result = await _userService.Set(user);
        if (!result.IsSuccessful) return BadRequest(
            new ErrorResponse(1, string.Join(';', result.Error!))
            );
        return Ok(result.Result);
    }
    
    [HttpPost("v1/auth/login")]
    public async Task<IActionResult> Login(UserCredentials userCredentials)
    {
        
        var result = await _userService.Authentication(userCredentials);
        if (!result.IsSuccessful) return BadRequest(new ErrorResponse(2, result.Error!));

        return Ok(result.Result.Id);
    }
    
}