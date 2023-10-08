using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace JusiLms.Models;

public class Role : IdentityRole
{
    [JsonIgnore]
    public ICollection<User> Users
    {
        get; set;
    } = null!;

}