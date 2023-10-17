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

    public override int SaveChanges()
    {
        var newEntities = this.ChangeTracker.Entries()
            .Where(
                x => x.State == EntityState.Added &&
                x.Entity != null &&
                x.Entity as ITimeStampedModel != null
                )
            .Select(x => x.Entity as ITimeStampedModel);

        var modifiedEntities = this.ChangeTracker.Entries()
            .Where(
                x => x.State == EntityState.Modified &&
                x.Entity != null &&
                x.Entity as ITimeStampedModel != null
                )
            .Select(x => x.Entity as ITimeStampedModel);

        foreach (var newEntity in newEntities)
        {
            newEntity.CreatedAt = DateTime.UtcNow;
            newEntity.LastModified = DateTime.UtcNow;
        }

        foreach (var modifiedEntity in modifiedEntities)
        {
            modifiedEntity.LastModified = DateTime.UtcNow;
        }

        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var newEntities = this.ChangeTracker.Entries()
            .Where(
                x => x.State == EntityState.Added &&
                x.Entity != null &&
                x.Entity as ITimeStampedModel != null
                )
            .Select(x => x.Entity as ITimeStampedModel);

        var modifiedEntities = this.ChangeTracker.Entries()
            .Where(
                x => x.State == EntityState.Modified &&
                x.Entity != null &&
                x.Entity as ITimeStampedModel != null
                )
            .Select(x => x.Entity as ITimeStampedModel);

        foreach (var newEntity in newEntities)
        {
            newEntity.CreatedAt = DateTime.UtcNow;
            newEntity.LastModified = DateTime.UtcNow;
        }

        foreach (var modifiedEntity in modifiedEntities)
        {
            modifiedEntity.LastModified = DateTime.UtcNow;
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
