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
}

