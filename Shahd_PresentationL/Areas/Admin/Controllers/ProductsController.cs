using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shahd_BusniessLL.Services.Classes;
using Shahd_BusniessLL.Services.Interfaces;
using Shahd_DataAccessL.DTO.Requests;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Shahd_PresentationL.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]

    public class ProductsController : ControllerBase
    {
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
        }

        [HttpGet ("")]
        public IActionResult GetAll() => Ok(_productService.GetAll());

        [HttpPost("")]
        public async Task<IActionResult> Create([FromForm] ProductRequest request)
        {
         
            var reasult =await _productService.CreateFile(request);
            return Ok(reasult);
        }

}
}
