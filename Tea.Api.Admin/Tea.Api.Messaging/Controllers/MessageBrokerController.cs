using Microsoft.AspNetCore.Mvc;
using Tea.Api.Entity.MessageBroker;
using Tea.Api.Service.Collection;
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

    }
}
