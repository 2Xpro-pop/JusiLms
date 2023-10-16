using JusiLms.Models;
using JusiLms.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JusiLms.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class HomeWorksController : ControllerBase
{
    private readonly IHomeWorksService _homeWorksService;

    public HomeWorksController(IHomeWorksService homeWorksService)
    {
        _homeWorksService = homeWorksService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllHomeWorks()
    {
        var homeWorks = await _homeWorksService.GetAllHomeWorks();
        return Ok(homeWorks);
    }

    [HttpPost]
    public async Task<IActionResult> Create(HomeWork work)
    {
        await _homeWorksService.Create(work);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update(HomeWork work)
    {
        await _homeWorksService.Update(work);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(HomeWork work)
    {
        await _homeWorksService.Delete(work);
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var homeWork = await _homeWorksService.Get(id);
        if (homeWork == null)
            return NotFound();

        return Ok(homeWork);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetUserHomeworks(Guid userId)
    {
        var homeWorks = await _homeWorksService.GetUserHomeworks(userId);
        return Ok(homeWorks);
    }

    [HttpPost("{userId}/{homeWorkId}")]
    public async Task<IActionResult> AddHomeworkToUser(Guid userId, Guid homeWorkId)
    {
        await _homeWorksService.AddHomeworkToUser(userId, homeWorkId);
        return Ok();
    }

    [HttpDelete("{userId}/{homeWorkId}")]
    public async Task<IActionResult> RemoveHomeworkToUser(Guid userId, Guid homeWorkId)
    {
        await _homeWorksService.RemoveHomeworkToUser(userId, homeWorkId);
        return Ok();
    }
}