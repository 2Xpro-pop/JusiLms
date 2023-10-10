using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace JusiLms.Models;

public class User : IdentityUser
{
    public string? Avatar
    {
        get; set;
    }
    public DateTime LastActivity
    {
        get; set;
    } = DateTime.MinValue;

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

    public string? FullName
    {
        get;
        set;
    } 

    public virtual ICollection<Role> Roles
    {
        get; set;
    }

    public virtual ICollection<HomeWork> HomeWorks
    {
        get; set;
    }
}
