using Microsoft.AspNetCore.Mvc;
using Tea.Api.Entity.Print;
using Tea.Api.Service.GoogleSheet;
using Tea.Api.Service.Print;

namespace Tea.Api.Print.Controllers
{
    [ApiController]
    [Route("[controller]")]

    
    public class SheetsController : ControllerBase
    {
        private  IGoogleSheetsService _sheetsService;

        public SheetsController(IGoogleSheetsService sheetsService)
        {
            _sheetsService=sheetsService;
        }

        [HttpPost("addSheet")]
        public async Task<IActionResult> AddRow([FromBody] SheetRowDto data)
        {
            var row = new List<object> { data.Name, data.Email, data.Message };
            await _sheetsService.AddAppointmentData("Sheet1", row);
            return Ok("Row added successfully!");
        }
    }
}
