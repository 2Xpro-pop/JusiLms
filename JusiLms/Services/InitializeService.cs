namespace JusiLms.Services;

using JusiLms.Data;
using JusiLms.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class InitializeService : IInitializeService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly IConfiguration _config;
    private readonly ILogger _logger;

    public InitializeService(ApplicationDbContext context,
                             UserManager<User> userManager,
                             SignInManager<User> signInManager,
                             IConfiguration config,
                             ILogger<InitializeService> logger,
                             RoleManager<Role> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
        _config = config;
        _logger = logger;
        _roleManager = roleManager;
    }

    public async Task InitializeAsync()
    {
        _logger.LogInformation("Initializing...");
        try
        {
            var pendingMigrations = await _context.Database.GetPendingMigrationsAsync();

            if (pendingMigrations.Any())
            {
                _logger.LogInformation("Applying pending database migrations.");
                await _context.Database.MigrateAsync();
                _logger.LogInformation("Database migration completed successfully.");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while applying database migrations.");
            throw;
        }


        var password = _config.GetRequiredSection("Admin").GetValue<string>("Password")!;

        var admin = new User()
        {
            UserName = "admin",
        };

        var foundedAdmin = await _userManager.FindByNameAsync("admin");
        if (foundedAdmin != null)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(foundedAdmin, password, false);

            if (result.Succeeded)
            {
                _logger.LogInformation("The admin already exists with the same password. Admin's id={Id}", foundedAdmin.Id);
                return;
            }

            _logger.LogInformation("Attempting to change the admin's password.");

            foundedAdmin.PasswordHash = _userManager.PasswordHasher.HashPassword(foundedAdmin, password);

            var changePasswordResult = await _userManager.UpdateAsync(foundedAdmin);

            if (changePasswordResult.Succeeded)
            {
                _logger.LogInformation("Admin's password was updated successfully.");
                return;
            }

            _logger.LogError("Failed to update admin's password. Errors: {Errors}", string.Join(", ", changePasswordResult.Errors.Select(e => e.Description)));
            return;
        }

        var hasRole = await _roleManager.Roles.AnyAsync(x => x.Name == "Admin");

        if (!hasRole)
        {
            var createRoleResult = await _roleManager.CreateAsync(new()
            {
                Name = "Admin",
            });

            if (createRoleResult.Succeeded)
            {
                _logger.LogInformation("The 'Admin' role was successfully created.");
            }
            else
            {
                _logger.LogError("Error creating the 'Admin' role: {Errors}", string.Join(", ", createRoleResult.Errors.Select(e => e.Description)));

                return;
            }

        }

        var createAdminResult = await _userManager.CreateAsync(admin, password);

        if (createAdminResult.Succeeded)
        {
            _logger.LogInformation("Admin user created successfully. Admin's id={Id}", admin.Id);

            var addToRoleResult = await _userManager.AddToRoleAsync(admin, "Admin");

            if (addToRoleResult.Succeeded)
            {
                _logger.LogInformation("Admin user added to the 'Admin' role.");
            }
            else
            {
                _logger.LogError("Error adding Admin user to the 'Admin' role: {Errors}", string.Join(", ", addToRoleResult.Errors.Select(e => e.Description)));
                throw new Exception("Failed to add Admin user to the 'Admin' role.");
            }

            return;
        }

        _logger.LogError("Failed to create admin user.");
        throw new InvalidOperationException("Failed to create admin user.");
    }

    public async Task AddDefaultRoles()
    {
    }
}
