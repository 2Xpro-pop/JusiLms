using JusiLms.Models;

namespace JusiLms.Services;

public interface ICategoryService
{
    public Task AddCategory(Category category);
    public Task DeleteCategory(Category category);
    public Task UpdateCategory(Category category);
    public Task<IEnumerable<Category>> GetCategories();

    public Task<Category?> GetCategory(Guid id);
}
