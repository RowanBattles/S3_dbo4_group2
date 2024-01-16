using System;
using MenuAPI_Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using Bussiness_API_Contract;

namespace Menumasters_MenuAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController
    {
        ICategoryComponent _categoryComponent;
        ILogger<CategoryController> _logger;

        public CategoryController(ICategoryComponent categoryComponent, ILogger<CategoryController> logger)
		{
            _categoryComponent = categoryComponent;
            _logger = logger;
		}
        [HttpGet(Name = "GetAllCategories")]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryComponent.GetAllCategoriesAsync();
        }

        [HttpGet("{id}", Name = "GetCategoryById")]
        public async Task<Category?> GetCategory(int id)
        {
            return await _categoryComponent.GetCategoryByIdAsync(id);
        }
    }
}

