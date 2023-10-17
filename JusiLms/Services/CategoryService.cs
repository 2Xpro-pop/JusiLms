using JusiLms.Data;
using JusiLms.Models;
using Microsoft.EntityFrameworkCore;

namespace JusiLms.Services;

public class CategoryService : ICategoryService
{
    private readonly ApplicationDbContext _context;

    public CategoryService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddCategory(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteCategory(Category category)
    {
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Category>> GetCategories()
    {
        return await _context.Categories.OrderBy(c => c.CreatedAt).ToArrayAsync();
    }
    public async Task<Category?> GetCategory(Guid id) => await _context.Categories.FindAsync(id);
    public async Task UpdateCategory(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }
}
