using MudBlazor;

namespace JusiLms.Models;

public class Category
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

    public string Icon
    {
        get; set;
    } = Icons.Material.Filled.Star;

    public string Color
    {
        get; set;
    } = "Secondary";

}