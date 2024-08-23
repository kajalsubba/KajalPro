using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Entity.Common;
using Tea.Api.Entity.MessageBroker;

namespace Tea.Api.Service.MessageBroker
{
    public interface IMessageBrokerService
    {

        Task<SaveReturnModel> ProduceSupplier(SupplierMessageModel _msg);

        Task<SaveReturnModel> ProduceStgList(MobileSTGList _msg);
    }
}
