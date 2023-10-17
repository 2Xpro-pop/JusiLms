using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace JusiLms.Models;

public class HomeWork : TimeStampedModel
{
    public Guid Id
    {
        get; set;
    }

    public string? Details
    {
        get; set;
    }

    public Guid CategoryId
    {
        get; set;
    }

    [IgnoreDataMember, JsonIgnore]
    public Category? Category
    {
        get; set;
    }

    public virtual ICollection<User>? Users
    {
        get; set;
    }

}
