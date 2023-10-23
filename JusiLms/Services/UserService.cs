using JusiLms.Dto;
using JusiLms.Exceptions;
using JusiLms.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JusiLms.Services;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;

    public UserService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task AddUser(UserDto userDto)
    {
        var result = await _userManager.CreateAsync(userDto, userDto.Password);

        if (!result.Succeeded)
        {
            var errorMessage = "Failed to create user: ";
            foreach (var error in result.Errors)
            {
                errorMessage += $"{error.Description}. ";
            }

            throw new ApplicationException(errorMessage);
        }
    }

    public async Task AddUsers(IEnumerable<UserDto> users)
    {
        foreach (var user in users)
        {
            await _userManager.CreateAsync(user, user.Password!);
        }
    }

    public async Task ChangePassword(User user, string newPassword)
    {
        var hash = _userManager.PasswordHasher.HashPassword(user, newPassword);
        user.PasswordHash = hash;

        await _userManager.UpdateAsync(user);
    }

    public async Task DeleteUser(User user)
    {
        await _userManager.DeleteAsync(user);
        TrackingCircuitHandler.Users.Remove(user.Id);
    }
    public async Task<IEnumerable<User>> GetAllUsers() => await _userManager.Users.OrderBy(u => u.CreatedAt).ToArrayAsync();
    public async Task<User?> GetUserByEmail(string email) => await _userManager.FindByEmailAsync(email);
    public async Task<User?> GetUserById(Guid id) => await _userManager.FindByIdAsync(id.ToString());
    public async Task<User?> GetUserByUsername(string username) => await _userManager.FindByNameAsync(username);
    public async Task UpdateUser(UpdateUserDto user)
    {
        var foundedUser = await GetUserById(Guid.Parse(user.Id)) ?? throw new NotFoundException();
        user.Override(foundedUser);

        var result = await _userManager.UpdateAsync(foundedUser);

        if (!result.Succeeded)
        {
            var errorMessage = "Failed to create user: ";
            foreach (var error in result.Errors)
            {
                errorMessage += $"{error.Description}. ";
            }

            throw new ApplicationException(errorMessage);
        }
    }
}
