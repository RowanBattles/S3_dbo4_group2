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

    [HttpPost(Name = "PostMenuItem")]
    public async Task<IActionResult> Post(MenuItem menuItem)
    {
        bool success = await _menuItemComponent.CreateMenuItemAsync(menuItem);
        return success ? Ok() : BadRequest();
    }

    [HttpPatch(Name = "PatchMenuItem")]
    public async Task<IActionResult> Patch(MenuItem menuItem)
    {
        bool success = await _menuItemComponent.UpdateMenuItemAsync(menuItem);
        return success ? Ok() : BadRequest();
    }

    [HttpDelete(Name = "DeleteMenuItem")]
    public async Task<IActionResult> Delete(int id)
    {
        bool success = await _menuItemComponent.DeleteMenuItemAsync(id);
        return success ? Ok() : BadRequest();
    }
}

