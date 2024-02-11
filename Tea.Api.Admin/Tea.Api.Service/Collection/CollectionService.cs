using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Data.UnitOfWork;
using Tea.Api.Entity.Collection;
using Tea.Api.Entity.Common;

namespace Tea.Api.Service.Collection
{
    public class CollectionService : ICollectionService
    {
        readonly IUnitOfWork _unitOfWork;
        public CollectionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       async Task<DataSet> ICollectionService.GetStgPendingData(StgFilterModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.GetStgPendingData(_input);
            return ds;
        }

      async  Task<SaveReturnModel> ICollectionService.SaveApproveStg(SaveApproveStg _input)
        {
            string msg = await _unitOfWork.CollectionRepository.SaveApproveStg(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }

        async Task<SaveReturnModel> ICollectionService.SaveSTG(SaveStgModel _input)
        {
            string msg = await _unitOfWork.CollectionRepository.SaveSTG(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }
    }
}
