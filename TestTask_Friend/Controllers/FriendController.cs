using System.Dynamic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using TestTask_Friend.APIStruct;
using TestTask_Friend.Errors;
using TestTask_Friend.Services;
using TestTask_Friend.Utils;

namespace TestTask_Friend.Controllers;

[ApiController]
public class FriendController : ControllerBase
{
    private readonly ILogger<FriendController> _logger;
    private readonly IUserService _userService;
    
    public FriendController(ILogger<FriendController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    /// <summary>
    /// Return user without password from database (by ID)
    /// </summary>
    /// <param name="id">User ID</param>
    [HttpGet("v1/user")]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IError), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetUserInfo([FromQuery] int id, CancellationToken cancellationToken)
    {
        var result = await _userService.Get(id, cancellationToken);
        return result.ToActionResult();
    }

    /// <summary>
    /// Register user 
    /// </summary>
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IError), StatusCodes.Status400BadRequest)]
    [HttpPost("v1/auth/register")]
    public async Task<IActionResult> Registration(UserRequest user, CancellationToken cancellationToken)
    {
        var result = await _userService.Set(user, cancellationToken);
        return result.ToActionResult();
    }
    
    /// <summary>
    /// User log in 
    /// </summary>
    /// <param name="userCredentials"></param>
    [HttpPost("v1/auth/login")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IError), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login(UserCredentials userCredentials, CancellationToken cancellationToken)
    {
        var result = await _userService.Authentication(userCredentials, cancellationToken);
        return result.ToActionResult();
    }
    
}

// enum ErrorCodes
// {
//     ValidationFailed,
//     AuthenticationFailed,
//     UserDoesNotExist,
// }