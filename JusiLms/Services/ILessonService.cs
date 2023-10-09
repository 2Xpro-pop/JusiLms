using JusiLms.Models;

namespace JusiLms.Services;

public interface ILessonsService
{
    public Task CreateLesson(Lesson lesson);
    public Task UpdateLesson(Lesson lesson);
    public Task DeleteLesson(Lesson lesson);
    public Task<Lesson?> GetLessonById(Guid id);
    public Task<IEnumerable<Lesson>> GetAllLessons();
    public Task<IEnumerable<Lesson>> GetLessonsByCategory(Guid categoryId);
}
