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
    public async Task<IEnumerable<HomeWork>> GetAllHomeWorks() => await _context.HomeWorks.ToArrayAsync();
    public async Task Update(HomeWork work)
    {
        _context.Update(work);
        await _context.SaveChangesAsync();
    }
}
