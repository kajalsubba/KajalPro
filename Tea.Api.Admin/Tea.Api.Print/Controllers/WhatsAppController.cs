using Microsoft.AspNetCore.Mvc;
using Tea.Api.Entity.Collection;
using Tea.Api.Entity.Print;
using Tea.Api.Service.Print;

namespace Tea.Api.Print.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WhatsAppController : ControllerBase
    {
        readonly IPrintService _printService;
        public WhatsAppController(IPrintService printService)
        {
            _printService=printService;
        }

        [HttpPost, Route("WhatsAppMessage")]
        public async Task<IActionResult> WhatsAppMessage([FromBody] WhatsAppModel _input)
        {
            var results = await _printService.WhatsAppMessage(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }
    }
}
