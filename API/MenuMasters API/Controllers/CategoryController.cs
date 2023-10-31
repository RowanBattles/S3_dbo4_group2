using Microsoft.AspNetCore.Mvc;
using Models;
using Contract_API_Bussiness.Interfaces;
using Bussiness_Factory;

namespace MenuMasters_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;
    private readonly ICategoryComponent _categoryComponent;

    public CategoryController(ILogger<CategoryController> logger)
    {
        _logger = logger;
        _categoryComponent = BussinessFactory.GetCategoryComponent();
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
        bool success = await _categoryComponent.CreateCategoryAsync(category);
        return success ? Ok() : BadRequest();
    }

    [HttpPatch(Name = "PatchCategory")]
    public async Task<IActionResult> Patch(Category category)
    {
        bool success = await _categoryComponent.UpdateCategoryAsync(category);
        return success ? Ok() : BadRequest();
    }

    [HttpDelete(Name = "DeleteCategory")]
    public async Task<IActionResult> Delete(int id)
    {
        bool success = await _categoryComponent.DeleteCategoryAsync(id);
        return success ? Ok() : BadRequest();
    }
}

