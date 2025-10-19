using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shahd_BusniessLL.Services.Interfaces;
using Shahd_DataAccessL.DTO.Requests;
using Shahd_DataAccessL.DTO.Responses;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Shahd_PresentationL.Areas.Customer.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Customer")]
    [Authorize(Roles = "Customer")]

    //[AllowAnonymous]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("")]

        public async Task< IActionResult> AddToCartAsync(CartRequest request)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("UserId from token is null");
            var result = await _cartService.AddToCartAsync(request, userId);

            return  result ? Ok() : BadRequest();

        }

        [HttpGet("")]
        public async Task<IActionResult> GetUserCartAsync()
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result =await _cartService.CartsummaryResponseAsync(userId);

            return  Ok(result) ;

        }
    }
}
