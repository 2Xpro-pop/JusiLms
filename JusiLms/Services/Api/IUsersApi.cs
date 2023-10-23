using JusiLms.Dto;
using JusiLms.Models;
using Refit;

namespace JusiLms.Services.Api;

public interface IUsersApi
{
    [Post("/api/Users")]
    Task AddUser([Body] UserDto user);

    [Put("/api/Users")]
    Task UpdateUser([Body] User user);

    [Delete("/api/Users")]
    Task DeleteUser([Body] User user);

    [Get("/api/Users/{id}")]
    Task<User> GetUserById(Guid id);

    [Get("/api/Users/email/{email}")]
    Task<User> GetUserByEmail(string email);

    [Get("/api/Users/username/{username}")]
    Task<User> GetUserByUsername(string username);

    [Get("/api/Users")]
    Task<IEnumerable<User>> GetAllUsers();

    [Post("/api/Users/add-multiple")]
    Task AddUsers([Body] IEnumerable<UserDto> users);
}
