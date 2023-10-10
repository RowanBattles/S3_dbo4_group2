using DataAccess;
using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MenuMasters_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;

    public CategoryController(ILogger<CategoryController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetAllCategories")]
    public async Task<IEnumerable<Category>> Get()
    {
        MenuMastersDbContext dbContext = new MenuMastersDbContext();
        CategoryRepository repo = new CategoryRepository(dbContext);
        return await repo.GetAllCategoriesAsync();
    }

    [HttpGet("{id}", Name = "GetCategoryById")]
    public async Task<Category?> Get(int id)
    {
        MenuMastersDbContext dbContext = new MenuMastersDbContext();
        CategoryRepository repo = new CategoryRepository(dbContext);
        return await repo.GetCategoryByIdAsync(id);
    }
}

