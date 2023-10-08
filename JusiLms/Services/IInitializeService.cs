namespace JusiLms.Services;

public interface IInitializeService
{
    Task AddDefaultRoles();
    Task InitializeAsync();
}