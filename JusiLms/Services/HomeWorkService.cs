using JusiLms.Data;
using JusiLms.Models;
using Microsoft.EntityFrameworkCore;

namespace JusiLms.Services;

public class HomeWorkService: IHomeWorksService
{
    private readonly ApplicationDbContext _context;

    public HomeWorkService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddHomeworkToUser(Guid userId, Guid homeWorkId)
    {
        var user = await _context.Users.Include(x => x.HomeWorks).FirstOrDefaultAsync(x => x.Id == userId.ToString());
        var homework = await _context.HomeWorks.FindAsync(homeWorkId);

        user.HomeWorks.Add(homework);

        await _context.SaveChangesAsync();
    }

    public async Task Create(HomeWork work)
    {
        _context.HomeWorks.Add(work);
        await _context.SaveChangesAsync();
    }
    public async Task Delete(HomeWork work)
    {
        _context.HomeWorks.Remove(work);
        await _context.SaveChangesAsync();
    }
    public async Task<HomeWork?> Get(Guid id) => await _context.HomeWorks.FindAsync(id);
    public async Task<IEnumerable<HomeWork>> GetAllHomeWorks() => await _context.HomeWorks.OrderBy(h => h.Category.CreatedAt).ToArrayAsync();
    public async Task<IEnumerable<HomeWork>?> GetUserHomeworks(Guid userId)
    {
        var user = await _context.Users.Include(x => x.HomeWorks!)
            .ThenInclude(x => x.Category)
            .Where(x => x.Id == userId.ToString())
            .FirstOrDefaultAsync();

        if (user == null)
        {
            return null;
        }

        return user.HomeWorks?.OrderBy(h => h.Category.CreatedAt);
    }
    public async Task RemoveHomeworkToUser(Guid userId, Guid homeWorkId)
    {
        var user = await _context.Users.Include(x => x.HomeWorks).FirstOrDefaultAsync(x => x.Id == userId.ToString());
        var homework = await _context.HomeWorks.FindAsync(homeWorkId);

        user.HomeWorks.Remove(homework);

        await _context.SaveChangesAsync();
    }

    public async Task Update(HomeWork work)
    {
        _context.Update(work);
        await _context.SaveChangesAsync();
    }
}
