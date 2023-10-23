using System.ComponentModel.DataAnnotations;
using JusiLms.Models;

namespace JusiLms.Dto;

public class UpdateUserDto
{
    public string? Id
    {
        get; set;
    } = null!;

    public string? Avatar
    {
        get; set;
    }

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

    public void Override(User user)
    {
        user.FullName = FullName;
        user.Avatar = Avatar;
        user.PhoneNumber = PhoneNumber;
        user.Email = Email;
        user.Wa = Wa;
        user.Insta = Insta;
        user.Tg = Tg;
    }

    public static implicit operator User(UpdateUserDto userDto)
    {
        var user = new User
        {
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

    public static implicit operator UpdateUserDto(User user)
    {
        return new UpdateUserDto
        {
            Id = user.Id,
            Avatar = user.Avatar,
            PhoneNumber = user.PhoneNumber,
            Email = user.Email,
            FullName = user.FullName,
            Insta = user.Insta,
            Tg = user.Tg,
            Wa = user.Wa
        };
    }
}