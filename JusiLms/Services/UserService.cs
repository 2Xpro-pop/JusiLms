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

    public async Task AddUser(User user)
    {
        await _userManager.CreateAsync(user, user.Password!);
    }

    public async Task AddUsers(IEnumerable<User> users)
    {
        foreach (var user in users)
        {
            await _userManager.CreateAsync(user, user.Password!);
        }
    }
    public async Task DeleteUser(User user)
    {
        await _userManager.DeleteAsync(user);
        TrackingCircuitHandler.Users.Remove(user.Id);
    }
    public async Task<IEnumerable<User>> GetAllUsers() => await _userManager.Users.ToArrayAsync();
    public async Task<User?> GetUserByEmail(string email) => await _userManager.FindByEmailAsync(email);
    public async Task<User?> GetUserById(Guid id) => await _userManager.FindByIdAsync(id.ToString());
    public async Task<User?> GetUserByUsername(string username) => await _userManager.FindByNameAsync(username);
    public async Task UpdateUser(User user) => await _userManager.UpdateAsync(user);
}
