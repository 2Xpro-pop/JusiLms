using JusiLms.Dto;
using JusiLms.Models;

namespace JusiLms.Services;

public interface IUserService
{
    public Task AddUser(UserDto userDto);
    public Task UpdateUser(UpdateUserDto user);
    public Task DeleteUser(User user);
    public Task<User?> GetUserById(Guid id);
    public Task<User?> GetUserByEmail(string email);
    public Task<User?> GetUserByUsername(string username);
    public Task<IEnumerable<User>> GetAllUsers();
    public Task AddUsers(IEnumerable<UserDto> users);
    public Task ChangePassword(User user, string newPassword);
}
