using DataAccess;
using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MenuMasters_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TabController : ControllerBase
{
    private readonly ILogger<TabController> _logger;

    public TabController(ILogger<TabController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetAllTabs")]
    public async Task<IEnumerable<Tab>> Get()
    {
        MenuMastersDbContext dbContext = new MenuMastersDbContext();
        TabRepository repo = new TabRepository(dbContext);
        return await repo.GetAllTabsAsync();
    }

    [HttpGet("{id}", Name = "GetTabById")]
    public async Task<Tab?> Get(int id)
    {
        MenuMastersDbContext dbContext = new MenuMastersDbContext();
        TabRepository repo = new TabRepository(dbContext);
        return await repo.GetTabByIdAsync(id);
    }
}

