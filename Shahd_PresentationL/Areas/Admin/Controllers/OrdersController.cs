using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shahd_BusniessLL.Services.Interfaces;
using Shahd_DataAccessL.Models;
using Stripe.Climate;

namespace Shahd_PresentationL.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService )
        {
            _orderService = orderService;
        }

        [HttpGet("status/{orderStatus}")]
        public async Task<IActionResult> GetOrderByStatus(OrderStatusEnum orderStatus)
        {
            var orders= await _orderService.GetByStatusAsync(orderStatus);
            return Ok(orders);
        }

        [HttpPatch("change-status/{orderId}")]
        public async Task<IActionResult> Changestatus([FromRoute] int orderId , [FromBody] OrderStatusEnum newStatus)
        {
            var orders = await _orderService.ChangestatusAsync(orderId, newStatus);
            return Ok(new {message="order status change succeesully"});
        }
    }
}
