using JusiLms.Data;
using JusiLms.Models;
using Microsoft.EntityFrameworkCore;

namespace JusiLms.Services;

public class LessonsService : ILessonsService
{
    private readonly ApplicationDbContext _context;
    public LessonsService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateLesson(Lesson lesson)
    {
        await _context.Lessons.AddAsync(lesson);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteLesson(Lesson lesson)
    {
        _context.Lessons.Remove(lesson);
        await _context.SaveChangesAsync();
    }
    public async Task<IEnumerable<Lesson>> GetAllLessons() => await _context.Lessons.OrderBy(l => l.CreatedAt).ToArrayAsync();
    public async Task<Lesson?> GetLessonById(Guid id) => await _context.Lessons.FindAsync(id);
    public async Task<IEnumerable<Lesson>> GetLessonsByCategory(Guid categoryId) => await _context.Lessons.Where(l => l.CategoryId == categoryId).OrderBy(l => l.CreatedAt).ToArrayAsync();
    public async Task UpdateLesson(Lesson lesson)
    {
        _context.Lessons.Update(lesson);
        await _context.SaveChangesAsync();
    }
}
