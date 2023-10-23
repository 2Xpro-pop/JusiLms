using JusiLms.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using JusiLms.Models;
using JusiLms.Dto;
using JusiLms.Exceptions;

namespace JusiLms.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> AddUser(UserDto user)
    {
        try
        {
            await _userService.AddUser(user);
        }
        catch (ApplicationException ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser(UpdateUserDto user)
    {
        try
        {
            await _userService.UpdateUser(user);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
        catch (ApplicationException ex)
        {
            return BadRequest(ex.Message);
        }
        
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
    public async Task<IActionResult> AddUsers(IEnumerable<UserDto> users)
    {
        await _userService.AddUsers(users);
        return Ok();
    }
    [HttpPut("change-password/{id}/{password}")]
    public async Task<IActionResult> ChangePassword(Guid id, string password)
    {
        var user = await _userService.GetUserById(id);

        if (user == null)
        {
            return NotFound();
        }

        await _userService.ChangePassword(user, password);

        return Ok();
    }
}
