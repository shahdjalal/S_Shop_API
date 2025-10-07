using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shahd_BusniessLL.Services.Interfaces;
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
        //private readonly ICategoryService _categoryService;

        //public  CategoriesController(ICategoryService categoryService)
        //{
        //    _categoryService = categoryService;
        //}

        //[HttpGet("")]

        //public IActionResult GetAll() => Ok(_categoryService.GetAll());
        

        //[HttpGet("{id}")]

        //public IActionResult GetById([FromRoute]int id)
        //{

        //    var category = _categoryService.GetById(id);
        //    if (category is null) return NotFound();
        //    return Ok(category);
        //}

        //[HttpPost ("")]
        //public IActionResult Create([FromBody] CategoryRequest request)
        //{
        //   var id = _categoryService.Create(request);
        //    return CreatedAtAction(nameof(GetAll),new { id } , new {message ="ok"});
        //}

        //[HttpPatch("{id}")]
        //public IActionResult Update([FromBody] CategoryRequest request, [FromRoute] int id)
        //{
        //    var updated = _categoryService.update(id ,request);
        //    return updated > 0 ? Ok() : NotFound();
        //}

        //[HttpPatch("ToggleStatus/{id}")]
        //public IActionResult ToggleStatus( [FromRoute] int id)
        //{
        //    var updated = _categoryService.ToggleStatus(id);
        //    return updated ? Ok() : NotFound();
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete([FromRoute] int id)
        //{
        //    var deleted = _categoryService.Delete(id);

        //    return deleted  > 0 ? Ok() : NotFound();
        //}
    }
}
