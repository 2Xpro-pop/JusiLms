using JusiLms.Models;
using JusiLms.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JusiLms.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory(Category category)
    {
        await _categoryService.AddCategory(category);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(Category category)
    {
        await _categoryService.DeleteCategory(category);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory(Category category)
    {
        await _categoryService.UpdateCategory(category);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _categoryService.GetCategories();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory(Guid id)
    {
        var category = await _categoryService.GetCategory(id);
        if (category == null)
            return NotFound();

        return Ok(category);
    }
}