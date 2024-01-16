using System;
using Bussiness_API_Contract;
using MenuAPI_Models;
using Microsoft.AspNetCore.Mvc;

namespace Menumasters_MenuAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
	{
        private readonly ILogger<MenuController> _logger;
        private readonly IMenuComponent _menuItemComponent;

        public MenuController(ILogger<MenuController> logger, IMenuComponent menuItemComponent)
        {
            _logger = logger;
            _menuItemComponent = menuItemComponent;
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
}

