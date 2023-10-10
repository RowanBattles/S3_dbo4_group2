using DataAccess;
using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MenuMasters_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuItemController : ControllerBase
{
    private readonly ILogger<MenuItemController> _logger;

    public MenuItemController(ILogger<MenuItemController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetAllMenuItems")]
    public async Task<IEnumerable<MenuItem>> Get()
    {
        MenuMastersDbContext dbContext = new MenuMastersDbContext();
        MenuItemRepository repo = new MenuItemRepository(dbContext);
        return await repo.GetAllMenuItemsAsync();
    }

    [HttpGet("{id}", Name = "GetMenuItemById")]
    public async Task<MenuItem?> Get(int id)
    {
        MenuMastersDbContext dbContext = new MenuMastersDbContext();
        MenuItemRepository repo = new MenuItemRepository(dbContext);
        return await repo.GetMenuItemByIdAsync(id);
    }
}

