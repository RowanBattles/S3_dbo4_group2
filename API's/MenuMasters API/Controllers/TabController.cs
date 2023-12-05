using Contract_API_Bussiness.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTOs;

namespace MenuMasters_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TabController : ControllerBase
{
    private readonly ILogger<TabController> _logger;
    private readonly ITabComponent _tabComponent;

    public TabController(ILogger<TabController> logger, ITabComponent tabComponent)
    {
        _logger = logger;
        _tabComponent = tabComponent;
    }

    [HttpGet(Name = "GetAllTabs")]
    public async Task<IEnumerable<SalesTab>> Get()
    {
        return await _tabComponent.GetAllTabsAsync();
    }

    [HttpGet("{id}", Name = "GetTabById")]
    public async Task<SalesTab?> Get(int id)
    {
        return await _tabComponent.GetTabByIdAsync(id);
    }

    [HttpPost(Name = "PostTab")]
    public async Task<IActionResult> Post(Tab tab)
    {
        Tab? result = await _tabComponent.CreateTabAsync(tab);
        return result != null ? Ok(result) : BadRequest(result);
    }

    [HttpPatch(Name = "PatchTab")]
    public async Task<IActionResult> Patch(Tab tab)
    {
        Tab? result = await _tabComponent.UpdateTabAsync(tab);
        return result != null ? Ok(result) : BadRequest(result);
    }

    [HttpDelete(Name = "DeleteTab")]
    public async Task<IActionResult> Delete(int id)
    {
        bool success = await _tabComponent.DeleteTabAsync(id);
        return success ? Ok() : BadRequest();
    }
}

