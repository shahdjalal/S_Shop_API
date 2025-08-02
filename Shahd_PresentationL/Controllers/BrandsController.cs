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
        public IActionResult Create([FromBody] BrandRequest request)
        {
            var id = _brandService.Create(request);
            return CreatedAtAction(nameof(GetAll), new { id }, new { message = "ok" });
        }

        [HttpPatch("{id}")]
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
