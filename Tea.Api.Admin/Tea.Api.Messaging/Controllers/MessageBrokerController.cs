using Microsoft.AspNetCore.Mvc;
using Tea.Api.Entity.MessageBroker;
using Tea.Api.Service.MessageBroker;

namespace Tea.Api.Messaging.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageBrokerController : ControllerBase
    {
        readonly IMessageBrokerService _messageBrokerService;
        public MessageBrokerController(IMessageBrokerService messageBrokerService)
        {
            _messageBrokerService= messageBrokerService;
        }


        [HttpPost, Route("ProduceSupplier")]
        public async Task<IActionResult> ProduceSupplier([FromForm] SupplierMessageModel _msg)
        {
            var results = await _messageBrokerService.ProduceSupplier(_msg);
            return (results != null) ? Ok(results) : throw new Exception();
        }


        [HttpPost, Route("ProduceStgList")]
        public async Task<IActionResult> ProduceStgList([FromBody] MobileSTGList _msg)
        {
            var results = await _messageBrokerService.ProduceStgList(_msg);
            return (results != null) ? Ok(results) : throw new Exception();
        }

        [HttpPost, Route("TransferSTGData")]
        public async Task<IActionResult> TransferSTGData([FromBody] TransferStgDataList _input)
        {
            var results = await _messageBrokerService.TransferSTGData(_input);
            return (results != null) ? Ok(results) : throw new Exception();
        }


    }
}
