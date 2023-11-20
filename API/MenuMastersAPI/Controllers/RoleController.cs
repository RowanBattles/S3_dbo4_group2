using Bussiness_Factory;
using Contract_API_Bussiness.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace MenuMasters_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly ILogger<RoleController> _logger;

    public RoleController(ILogger<RoleController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetAllRoles")]
    public async Task<IEnumerable<Role>> Get()
    {
        //MenuMastersDbContext dbContext = new MenuMastersDbContext();
        //RoleRepository repo = new RoleRepository(dbContext);
        //return await repo.GetAllRolesAsync();
        throw new NotImplementedException();
    }

    [HttpGet("{id}", Name = "GetRoleById")]
    public async Task<Role?> Get(int id)
    {
        //MenuMastersDbContext dbContext = new MenuMastersDbContext();
        //RoleRepository repo = new RoleRepository(dbContext);
        //return await repo.GetRoleByIdAsync(id);
        throw new NotImplementedException();
    }
}

