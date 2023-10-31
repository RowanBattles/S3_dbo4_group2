using Bussiness_Factory;
using Contract_API_Bussiness.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace MenuMasters_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenuItemController : ControllerBase
{
    private readonly ILogger<MenuItemController> _logger;
    private readonly IMenuItemComponent _menuItemComponent;

    public MenuItemController(ILogger<MenuItemController> logger)
    {
        _logger = logger;
        _menuItemComponent = BussinessFactory.GetMenuItemComponent();
    }

    [HttpGet(Name = "GetAllMenuItems")]
    public async Task<IEnumerable<MenuItem>> Get()
    {
        return await _menuItemComponent.GetAllMenuItemsAsync();
    }

    [HttpGet("{id}", Name = "GetMenuItemById")]
    public async Task<MenuItem?> Get(int id)
    {
        return await _menuItemComponent.GetMenuItemByIdAsync(id);
    }
}

