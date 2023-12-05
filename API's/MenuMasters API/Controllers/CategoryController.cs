using Microsoft.AspNetCore.Mvc;
using Models;
using Contract_API_Bussiness.Interfaces;

namespace MenuMasters_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;
    private readonly ICategoryComponent _categoryComponent;

    public CategoryController(ILogger<CategoryController> logger, ICategoryComponent categoryComponent)
    {
        _logger = logger;
        _categoryComponent = categoryComponent;
    }

    [HttpGet(Name = "GetAllCategories")]
    public async Task<IEnumerable<Category>> Get()
    {
        return await _categoryComponent.GetAllCategoriesAsync();
    }

    [HttpGet("{id}", Name = "GetCategoryById")]
    public async Task<Category?> Get(int id)
    {
        return await _categoryComponent.GetCategoryByIdAsync(id);
    }

    [HttpPost(Name = "PostCategory")]
    public async Task<IActionResult> Post(Category category)
    {
        Category result = await _categoryComponent.CreateCategoryAsync(category);
        return result != null ? Ok(result) : BadRequest(result);
    }

    [HttpPatch(Name = "PatchCategory")]
    public async Task<IActionResult> Patch(Category category)
    {
        Category? result = await _categoryComponent.UpdateCategoryAsync(category);
        return result != null ? Ok(result) : BadRequest(result);
    }

    [HttpDelete(Name = "DeleteCategory")]
    public async Task<IActionResult> Delete(int id)
    {
        bool success = await _categoryComponent.DeleteCategoryAsync(id);
        return success ? Ok() : BadRequest();
    }
}

