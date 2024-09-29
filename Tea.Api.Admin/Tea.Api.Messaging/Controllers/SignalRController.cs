using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Tea.Api.Entity.MessageBroker;
using Tea.Api.Service.SignalR;

namespace Tea.Api.Messaging.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignalRController : ControllerBase
    {
        private IHubContext<MessageHubClient, IMessageHubClient> messageHub;

        public SignalRController(IHubContext<MessageHubClient, IMessageHubClient> _messageHub)
        {
            messageHub = _messageHub;
        }
       
        [HttpPost, Route("SendNotification")]
        public async Task<IActionResult> SendNotification(bool Message,int TenantId)
        {
            await messageHub.Clients.All.SendNotification(Message, TenantId);
            return Ok("Yes");
        }

    }
}
