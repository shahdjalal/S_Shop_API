using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shahd_BusniessLL.Services.Interfaces;
using Shahd_DataAccessL.DTO.Requests;

namespace Shahd_PresentationL.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]

    public class BrandsController : ControllerBase
    {
    private readonly IBrandService _brandService;

    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpGet("")]

    public IActionResult GetAll() => Ok(_brandService.GetAll());


    [HttpGet("{id}")]

    public IActionResult GetById([FromRoute] int id)
    {

        var brand = _brandService.GetById(id);
        if (brand is null) return NotFound();
        return Ok(brand);
    }

    [HttpPost("")]
    [Authorize]
    public IActionResult Create([FromBody] BrandRequest request)
    {
        var id = _brandService.Create(request);
        return CreatedAtAction(nameof(GetAll), new { id }, new { message = "ok" });
    }

    [HttpPatch("{id}")]
    [Authorize]
    public IActionResult Update([FromBody] BrandRequest request, [FromRoute] int id)
    {
        var updated = _brandService.update(id, request);
        return updated > 0 ? Ok() : NotFound();
    }

    [HttpPatch("ToggleStatus/{id}")]
    public IActionResult ToggleStatus([FromRoute] int id)
    {
        var updated = _brandService.ToggleStatus(id);
        return updated ? Ok() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var deleted = _brandService.Delete(id);

        return deleted > 0 ? Ok() : NotFound();
    }
}
}
