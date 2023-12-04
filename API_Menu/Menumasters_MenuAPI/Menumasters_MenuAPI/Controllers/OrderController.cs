using System;
using Bussiness_API_Contract;
using Bussiness_API_Factory;
using MenuAPI_Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Menumasters_MenuAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
	{
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderComponent _orderComponent;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
            _orderComponent = BussinessFactory.GetOrderComponent();
        }

        [HttpGet("{id}", Name = "GetOrderById")]
        public async Task<Order?> Get(int id)
        {
            return await _orderComponent.GetOrderByIdAsync(id);
        }

        [HttpPost("Item", Name = "PostOrderItem")]
        public async Task<IActionResult> PostOrderItem(OrderItem orderItem)
        {
            bool success = await _orderComponent. AddItemToOrderAsync(orderItem);
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
}

