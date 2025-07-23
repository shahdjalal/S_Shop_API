using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shahd_BusniessLL.Services;
using Shahd_DataAccessL.Data;
using Shahd_DataAccessL.DTO.Requests;
using Shahd_DataAccessL.Models;
using Shahd_DataAccessL.Repositories;

namespace Shahd_PresentationL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public  CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("")]

        public IActionResult GetAll()
        {
            return Ok(categoryService.GetAllCategories());
        }

        [HttpGet("{id}")]

        public IActionResult GetById([FromRoute]int id)
        {

            var category = categoryService.GetCategoryById(id);
            if (category is null) return NotFound();
            return Ok(category);
        }

        [HttpPost ("")]
        public IActionResult Create([FromBody] CategoryRequest request)
        {
           var id = categoryService.CreateCategory(request);
            return CreatedAtAction(nameof(GetById),new {id});
        }

        [HttpPatch("{id}")]
        public IActionResult Update([FromBody] CategoryRequest request, [FromRoute] int id)
        {
            var updated = categoryService.updateCategory(id ,request);
            return updated > 0 ? Ok() : NotFound();
        }

        [HttpPatch("ToggleStatus/{id}")]
        public IActionResult ToggleStatus( [FromRoute] int id)
        {
            var updated = categoryService.ToggleStatus(id);
            return updated ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var deleted = categoryService.DeleteCategory(id);

            return deleted  > 0 ? Ok() : NotFound();
        }
    }
}
