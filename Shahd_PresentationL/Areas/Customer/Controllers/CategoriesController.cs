using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shahd_BusniessLL.Services.Interfaces;

namespace Shahd_PresentationL.Areas.Customer.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Customer")]
    [Authorize(Roles="Customer")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("")]
        public IActionResult GetAll() => Ok(_categoryService.GetAll(false));


        [HttpGet("{id}")]

        public IActionResult GetById([FromRoute] int id)
        {

            var category = _categoryService.GetById(id);
            if (category is null) return NotFound();
            return Ok(category);
        }
    }
}
