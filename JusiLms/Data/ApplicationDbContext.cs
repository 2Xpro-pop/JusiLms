using JusiLms.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JusiLms.Data;
public class ApplicationDbContext : IdentityDbContext<User, Role, string>
{
    public DbSet<Category> Categories
    {
        get; set;
    }

    public DbSet<Lesson> Lessons
    {
        get; set;
    }

    public DbSet<HomeWork> HomeWorks
    {
        get; set;
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
