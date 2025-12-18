using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using Tea.Api.Entity.Print;
using Tea.Api.Service.GoogleSheet;
using Tea.Api.Entity.Print;

namespace Tea.Api.Print.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SheetsController : ControllerBase
    {
        private IGoogleSheetsService _sheetsService;

        public SheetsController(IGoogleSheetsService sheetsService)
        {
            _sheetsService = sheetsService;
        }


        [HttpPost, Route("addSheet")]
        public async Task<IActionResult> AddRow([FromBody] GoogleSheetModel data)
        {
            var row = new List<object>
            {
            data.Name ?? "",
            data.Email ?? "",
            data.Phone ?? "",
            data.PreferredDate ?? "",
            data.ServiceInterest ?? "",
            DateTime.Now.ToString("dd/MMM/yyyy")
            };
            await _sheetsService.AddAppointmentData("DataSheet", row);
            return Ok("Row added successfully!");
        }
    }
}
