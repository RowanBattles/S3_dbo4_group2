using DataAccess;
using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MenuMasters_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetAllAccounts")]
    public async Task<IEnumerable<Account>> Get()
    {
        MenuMastersDbContext dbContext = new MenuMastersDbContext();
        AccountRepository repo = new AccountRepository(dbContext);
        return await repo.GetAllAccountsAsync();
    }

    [HttpGet("{id}", Name = "GetAccountById")]
    public async Task<Account?> Get(int id)
    {
        MenuMastersDbContext dbContext = new MenuMastersDbContext();
        AccountRepository repo = new AccountRepository(dbContext);
        return await repo.GetAccountByIdAsync(id);
    }
}

