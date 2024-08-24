using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Entity.Common;
using Tea.Api.Entity.MessageBroker;

namespace Tea.Api.Data.Repository.MessageBroker
{
    public interface IRabitMQProducer
    {
        Task <string> SendProductMessage(SupplierMessageModel  message);

        Task<string> ProduceStgList(MobileSTGList message);

        Task<string> TransferSTGData(TransferStgDataList _input);

    }
}
