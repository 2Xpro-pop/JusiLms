namespace JusiLms.Models;

public class HomeWork
{
    public Guid Id
    {
        get; set;
    }

    public string? Details
    {
        get; set;
    }

    public virtual ICollection<User> Users
    {
        get; set;
    }

}
