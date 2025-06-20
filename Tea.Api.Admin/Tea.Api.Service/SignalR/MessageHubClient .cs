using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Service.SignalR
{
    public class MessageHubClient :Hub<IMessageHubClient>
    {
        public async Task SendNotification(bool message, int TenantId)
        {
            await Clients.All.SendNotification(message, TenantId);
            
        }

    }
}
