using JusiLms.Models;
using JusiLms.Services;
using Microsoft.AspNetCore.Mvc;

namespace JusiLms.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LessonsController : ControllerBase
{
    private readonly ILessonsService _lessonsService;

    public LessonsController(ILessonsService lessonsService)
    {
        _lessonsService = lessonsService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateLesson(Lesson lesson)
    {
        await _lessonsService.CreateLesson(lesson);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateLesson(Lesson lesson)
    {
        await _lessonsService.UpdateLesson(lesson);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteLesson(Lesson lesson)
    {
        await _lessonsService.DeleteLesson(lesson);
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLessonById(Guid id)
    {
        var lesson = await _lessonsService.GetLessonById(id);
        if (lesson == null)
            return NotFound();

        return Ok(lesson);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllLessons()
    {
        var lessons = await _lessonsService.GetAllLessons();
        return Ok(lessons);
    }

    [HttpGet("category/{categoryId}")]
    public async Task<IActionResult> GetLessonsByCategory(Guid categoryId)
    {
        var lessons = await _lessonsService.GetLessonsByCategory(categoryId);
        return Ok(lessons);
    }
}