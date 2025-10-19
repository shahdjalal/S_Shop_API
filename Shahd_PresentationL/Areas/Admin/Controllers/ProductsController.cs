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
        public IActionResult GetAll([FromQuery] int pageNumber=1, [FromQuery] int pageSize =5) 
        {
        var products= _productService.GetAllProducts(Request, false, pageNumber,pageSize);
            return Ok(products);
        
        } 

        [HttpPost("")]
        public async Task<IActionResult> Create([FromForm] ProductRequest request)
        {
         
            var reasult =await _productService.CreateProduct(request);
            return Ok(reasult);
        }

}
}
