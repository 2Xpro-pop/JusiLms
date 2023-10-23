using System.ComponentModel.DataAnnotations;
using JusiLms.Models;

namespace JusiLms.Dto;

public class UserDto
{
    public string? Id
    {
        get; set;
    } = null!;

    public string? Avatar
    {
        get; set;
    }

    [Required, MinLength(4, ErrorMessage = "Минимальная длинная логина 5")]
    [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Логин должен содержать только буквы")]
    public string Login
    {
        get; set;
    } = null!;

    [Required, MinLength(5, ErrorMessage = "Пароль необходим")]
    public string Password
    {
        get; set;
    } = null!;

    public string? PhoneNumber
    {
        get; set;
    }

    public string? Email
    {
        get; set;
    }

    public string? FullName
    {
        get;
        set;
    }

    public string? Insta
    {
        get; set;
    }
    public string? Tg
    {
        get; set;
    }
    public string? Wa
    {
        get; set;
    }

    public static implicit operator User(UserDto userDto)
    {
        var user = new User
        {
            UserName = userDto.Login,
            Avatar = userDto.Avatar,
            Email = userDto.Email,
            FullName = userDto.FullName,
            PhoneNumber = userDto.PhoneNumber,
            Insta = userDto.Insta,
            Tg = userDto.Tg,
            Wa = userDto.Wa,
        };
        if (!string.IsNullOrWhiteSpace(userDto.Id))
        {
            user.Id = userDto.Id;
        }
        return user;
    }

    public static implicit operator UserDto(User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Avatar = user.Avatar,
            Login = user.UserName,
            PhoneNumber = user.PhoneNumber,
            Email = user.Email,
            FullName = user.FullName,
            Insta = user.Insta,
            Tg = user.Tg,
            Wa = user.Wa
        };
    }
}