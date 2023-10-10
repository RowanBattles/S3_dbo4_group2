using DataAccess;
using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MenuMasters_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;

    public OrderController(ILogger<OrderController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetAllOrders")]
    public async Task<IEnumerable<Order>> Get()
    {
        MenuMastersDbContext dbContext = new MenuMastersDbContext();
        OrderRepository repo = new OrderRepository(dbContext);
        return await repo.GetAllOrdersAsync();
    }

    [HttpGet("{id}", Name = "GetOrderById")]
    public async Task<Order?> Get(int id)
    {
        MenuMastersDbContext dbContext = new MenuMastersDbContext();
        OrderRepository repo = new OrderRepository(dbContext);
        return await repo.GetOrderByIdAsync(id);
    }
}

