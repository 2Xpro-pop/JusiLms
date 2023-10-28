using JusiLms.Models;
using Refit;

namespace JusiLms.Services.Api;

public interface IHomeWorksApi
{
    [Get("/api/HomeWorks")]
    Task<IEnumerable<HomeWork>> GetAllHomeWorks();

    [Post("/api/HomeWorks")]
    Task Create([Body] HomeWork work);

    [Put("/api/HomeWorks")]
    Task Update([Body] HomeWork work);

    [Delete("/api/HomeWorks/{id}")]
    Task Delete(Guid id);

    [Get("/api/HomeWorks/{id}")]
    Task<HomeWork> Get(Guid id);

    [Get("/api/HomeWorks/user/{userId}")]
    Task<IEnumerable<HomeWork>> GetUserHomeworks(Guid userId);

    [Post("/api/HomeWorks/{userId}/{homeWorkId}")]
    Task AddHomeworkToUser(Guid userId, Guid homeWorkId);

    [Delete("/api/HomeWorks/{userId}/{homeWorkId}")]
    Task RemoveHomeworkToUser(Guid userId, Guid homeWorkId);
}
