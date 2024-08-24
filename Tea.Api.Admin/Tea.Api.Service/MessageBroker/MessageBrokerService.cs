using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Data.UnitOfWork;
using Tea.Api.Entity.Common;
using Tea.Api.Entity.MessageBroker;

namespace Tea.Api.Service.MessageBroker
{
    public class MessageBrokerService : IMessageBrokerService
    {
        readonly IUnitOfWork _unitOfWork;
        public MessageBrokerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

       async Task<SaveReturnModel> IMessageBrokerService.ProduceStgList(MobileSTGList _msg)
        {
            string msg = await _unitOfWork.RabitMQProducer.ProduceStgList(_msg);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }

        async Task<SaveReturnModel> IMessageBrokerService.ProduceSupplier(SupplierMessageModel _msg)
        {
            string msg =await _unitOfWork.RabitMQProducer.SendProductMessage(_msg);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }

      async  Task<SaveReturnModel> IMessageBrokerService.TransferSTGData(TransferStgDataList _input)
        {
            string msg = await _unitOfWork.RabitMQProducer.TransferSTGData(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }
    }
}
