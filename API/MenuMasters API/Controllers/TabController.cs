using Bussiness;
using Bussiness_Factory;
using Contract_API_Bussiness.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace MenuMasters_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TabController : ControllerBase
{
    private readonly ILogger<TabController> _logger;
    private readonly ITabComponent _tabComponent;

    public TabController(ILogger<TabController> logger)
    {
        _logger = logger;
        _tabComponent = BussinessFactory.GetTabComponent();
    }

    [HttpGet(Name = "GetAllTabs")]
    public async Task<IEnumerable<Tab>> Get()
    {
        return await _tabComponent.GetAllTabsAsync();
    }

    [HttpGet("{id}", Name = "GetTabById")]
    public async Task<Tab?> Get(int id)
    {
        return await _tabComponent.GetTabByIdAsync(id);
    }
}

