using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace JusiLms.Models;

public class User: IdentityUser
{
    [JsonIgnore, IgnoreDataMember]
    public override string PasswordHash
    {
        get; set;
    }

    [NotMapped]
    public string? Password
    {
        get; set;
    }

    [NotMapped]
    public string? ConfirmPassword
    {
        get; set;
    }

    [JsonIgnore, IgnoreDataMember, NotMapped]
    public string Name
    {
        get
        {
            return UserName;
        }
        set
        {
            UserName = value;
        }
    }

    public ICollection<Role> Roles
    {
        get; set;
    }
}
