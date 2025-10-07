using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shahd_BusniessLL.Services.Interfaces;
using Shahd_DataAccessL.DTO.Requests;
using System.Security.Claims;

namespace Shahd_PresentationL.Areas.Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Area("Customer")]
    [Authorize(Roles = "Customer")]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("")]

        public IActionResult AddToCart(CartRequest request)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = _cartService.AddToCart(request, userId);

            return result ? Ok() : BadRequest();

        }
    }
}
