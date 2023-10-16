using JusiLms.Models;
using Refit;

namespace JusiLms.Services.Api;

public interface ICategoryApi
{
    [Post("/api/Categories")]
    Task AddCategory([Body] Category category);

    [Delete("/api/Categories")]
    Task DeleteCategory([Body] Category category);

    [Put("/api/Categories")]
    Task UpdateCategory([Body] Category category);

    [Get("/api/Categories")]
    Task<IEnumerable<Category>> GetCategories();

    [Get("/api/Categories/{id}")]
    Task<Category> GetCategory(Guid id);
}
