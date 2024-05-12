using Microsoft.AspNetCore.Mvc;
using Tea.Api.Entity.Collection;
using Tea.Api.Entity.Print;
using Tea.Api.Service.Print;

namespace Tea.Api.Print.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrintController : ControllerBase
    {
        readonly IPrintService _printService;
        public PrintController(IPrintService printService)
        {
            _printService = printService;
        }

        [HttpPost, Route("StgBillPrint")]
        public async Task<IActionResult> StgBillPrint([FromBody] BillPrintModel _input)
        {
            byte[] pdfBytes = await _printService.StgBillPrint(_input);
            return File(pdfBytes, "application/pdf", "your_filename.pdf");
        }
    }
}
