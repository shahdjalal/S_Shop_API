using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shahd_BusniessLL.Services.Interfaces;
using Shahd_DataAccessL.DTO.Requests;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Shahd_PresentationL.Areas.Customer.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Customer")]
    [Authorize(Roles="Customer")]
    public class CheckOutsController : ControllerBase
    {
        private readonly ICheckOutService _checkOutService;

        public CheckOutsController(ICheckOutService checkOutService)
        {
            _checkOutService = checkOutService;
        }

        [HttpPost("payment")]

        public async Task<IActionResult> Payment([FromBody] CheckOutRequest request)
        {
            var userId=User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _checkOutService.processPaymentasync(request, userId, Request);
            return Ok(response);
        }

        [HttpGet("Success/{orderId}")]
        [AllowAnonymous]
        public async Task<IActionResult> Success([FromRoute] int orderId)
        {

            var result =await _checkOutService.handlePaymentasync(orderId);
            return Ok(result);
        }
    }
}
