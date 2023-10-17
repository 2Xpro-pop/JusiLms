using System.Text.Json.Serialization;

namespace JusiLms.Models;

public class Lesson: TimeStampedModel
{
    public Guid Id
    {
        get; set;
    } = Guid.NewGuid();

    public string Header
    {
        get; set;
    } = null!;

    public string Description
    {
        get; set;
    } = null!;

    public string YoutubeUrl
    {
        get; set;
    } = null!;

    public Guid CategoryId
    {
        get; set;
    }
    public virtual Category? Category
    {
        get; set;
    } = null!;
}
