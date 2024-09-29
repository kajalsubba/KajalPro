using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Service.SignalR
{
    public interface IMessageHubClient
    {
        Task SendNotification(bool? message,int? TenantId);

    }
}
