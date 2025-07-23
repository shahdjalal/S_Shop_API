using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shahd_DataAccessL.Data;
using Shahd_DataAccessL.Models;

namespace Shahd_PresentationL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context )
        {
            _context = context;
        }
    }
}
