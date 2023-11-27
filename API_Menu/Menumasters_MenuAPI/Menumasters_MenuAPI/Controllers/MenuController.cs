using System;
using Bussiness_API_Contract;
using Bussiness_API_Factory;
using MenuAPI_Models;
using Microsoft.AspNetCore.Mvc;

namespace Menumasters_MenuAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
	{
        private readonly ILogger<MenuController> _logger;
        private readonly IMenuItemComponent _menuItemComponent;

        public MenuController(ILogger<MenuController> logger)
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
}

