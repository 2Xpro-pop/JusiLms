using JusiLms.Models;

namespace JusiLms.Services;

public interface IHomeWorksService
{
    public Task<IEnumerable<HomeWork>> GetAllHomeWorks();
    public Task Create(HomeWork work);
    public Task Update(HomeWork work);
    public Task Delete(HomeWork work);
    public Task<HomeWork?> Get(Guid id);
}
