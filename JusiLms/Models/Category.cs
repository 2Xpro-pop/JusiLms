using MudBlazor;

namespace JusiLms.Models;

public class Category : TimeStampedModel
{
    public Guid Id
    {
        get; set;
    } = Guid.NewGuid();

    public string Name
    {
        get; set;
    }

    public string Description
    {
        get; set;
    }

    public string? Icon
    {
        get; set;
    }

    public string Color
    {
        get; set;
    } = "Secondary";

    public virtual ICollection<HomeWork>? HomeWorks
    {
        get; set;
    }

}