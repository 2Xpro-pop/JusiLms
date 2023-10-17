namespace JusiLms.Models;

public class HomeWork: TimeStampedModel
{
    public Guid Id
    {
        get; set;
    }

    public string? Details
    {
        get; set;
    }

    public virtual ICollection<User>? Users
    {
        get; set;
    }

}
