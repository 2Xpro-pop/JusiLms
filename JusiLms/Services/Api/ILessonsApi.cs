using JusiLms.Models;
using Refit;

namespace JusiLms.Services.Api;

public interface ILessonsApi
{
    [Post("/api/Lessons")]
    Task CreateLesson([Body] Lesson lesson);

    [Put("/api/Lessons")]
    Task UpdateLesson([Body] Lesson lesson);

    [Delete("/api/Lessons")]
    Task DeleteLesson([Body] Lesson lesson);

    [Get("/api/Lessons/{id}")]
    Task<Lesson> GetLessonById(Guid id);

    [Get("/api/Lessons")]
    Task<IEnumerable<Lesson>> GetAllLessons();

    [Get("/api/Lessons/category/{categoryId}")]
    Task<IEnumerable<Lesson>> GetLessonsByCategory(Guid categoryId);
}