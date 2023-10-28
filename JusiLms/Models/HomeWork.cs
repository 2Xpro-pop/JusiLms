using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace JusiLms.Models;

public class HomeWork : TimeStampedModel
{
    public Guid Id
    {
        get; set;
    }
    public string Header
    {
        get; set;
    }
    [Required(ErrorMessage = "Необходимо описание задание")]
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

    [Range(1, 3, ErrorMessage = "Минимальная сложность 1, а максимальная 3")]
    public int Difficulty
    {
        get; set;
    }

}
