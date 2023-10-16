using JusiLms.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JusiLms.Models;

namespace JusiLms.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> AddUser(User user)
    {
        await _userService.AddUser(user);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser(User user)
    {
        await _userService.UpdateUser(user);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUser(User user)
    {
        await _userService.DeleteUser(user);
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var user = await _userService.GetUserById(id);
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpGet("email/{email}")]
    public async Task<IActionResult> GetUserByEmail(string email)
    {
        var user = await _userService.GetUserByEmail(email);
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpGet("username/{username}")]
    public async Task<IActionResult> GetUserByUsername(string username)
    {
        var user = await _userService.GetUserByUsername(username);
        if (user == null)
            return NotFound();

        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsers();
        return Ok(users);
    }

    [HttpPost("add-multiple")]
    public async Task<IActionResult> AddUsers(IEnumerable<User> users)
    {
        await _userService.AddUsers(users);
        return Ok();
    }
}
