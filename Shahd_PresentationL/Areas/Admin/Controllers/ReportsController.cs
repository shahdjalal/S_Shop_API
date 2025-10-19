using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using Shahd_BusniessLL.Services.Classes;

namespace Shahd_PresentationL.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class ReportsController : ControllerBase
    {
        private readonly ReportService _reportService;

        public ReportsController(ReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("PdfProduct")]

        public IResult GetPdfProductReport()
        {
   
            var document =_reportService.CreateDocument();

            // generate PDF file and return it as a response
            var pdf = document.GeneratePdf();
            return Results.File(pdf, "application/pdf", "s-products.pdf");

        }
    }
}
