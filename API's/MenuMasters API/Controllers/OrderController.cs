using Contract_API_Bussiness.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTOs;

namespace MenuMasters_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private readonly IOrderComponent _orderComponent;

    public OrderController(ILogger<OrderController> logger, IOrderComponent orderComponent)
    {
        _logger = logger;
        _orderComponent = orderComponent;
    }

    [HttpGet(Name = "GetAllOrders")]
    public async Task<IEnumerable<Order>> Get()
    {
        return await _orderComponent.GetAllOrdersAsync();
    }

    [HttpGet("Kitchen", Name = "GetAllKitchenOrders")]
    public async Task<IEnumerable<KitchenOrder>> GetKitchen()
    {
        return await _orderComponent.GetAllKitchenOrdersAsync();
    }

    [HttpGet("Bar", Name = "GetAllBarOrders")]
    public async Task<IEnumerable<KitchenOrder>> GetBar()
    {
        return await _orderComponent.GetAllBarOrdersAsync();
    }

    [HttpGet("Sales", Name = "GetAllSalesOrders")]
    public async Task<IEnumerable<SalesOrder>> GetSales()
    {
        return await _orderComponent.GetAllSalesOrdersAsync();
    }

    [HttpGet("{id}", Name = "GetOrderById")]
    public async Task<Order?> Get(int id)
    {
        return await _orderComponent.GetOrderByIdAsync(id);
    }

    [HttpPost(Name = "PostOrder")]
    public async Task<IActionResult> Post(PostOrder postOrder)
    {

        Order order = new Order()
        {
            TabId = postOrder.TabId,
            Status = Models.Enums.OrderStatus.Pending,
            DateTime = DateTime.Now,
            OrderItems = new List<OrderItem>()
        };

        foreach (PostOrderItem postOrderItem in postOrder.orderItems)
        {
            OrderItem orderItem = new OrderItem()
            {
                MenuItemId = postOrderItem.MenuItemId,
                Notes = postOrderItem.Notes,
                Quantity = postOrderItem.Quantity
            };
            order.OrderItems.Add(orderItem);
        }

        bool success = await _orderComponent.CreateOrderAsync(order);

        return success ? Ok() : BadRequest();
    }

    [HttpPost("Item", Name = "PostOrderItem")]
    public async Task<IActionResult> PostOrderItem(OrderItem orderItem)
    {
        bool success = await _orderComponent.AddItemToOrderAsync(orderItem);
        return success ? Ok() : BadRequest();
    }

    [HttpPatch(Name = "PatchOrder")]
    public async Task<IActionResult> Patch(Order order)
    {
        bool success = await _orderComponent.UpdateOrderAsync(order);
        return success ? Ok() : BadRequest();
    }

    [HttpDelete("Item", Name = "DeleteOrderItem")]
    public async Task<IActionResult> DeleteOrderItem(int id)
    {
        bool success = await _orderComponent.RemoveItemFromOrderAsync(id);
        return success ? Ok() : BadRequest();
    }

    [HttpDelete(Name = "DeleteOrder")]
    public async Task<IActionResult> Delete(int id)
    {
        bool success = await _orderComponent.DeleteOrderAsync(id);
        return success ? Ok() : BadRequest();
    }
}

