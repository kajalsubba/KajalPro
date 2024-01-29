using System;
using System.Collections.Generic;
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
        async Task<SaveReturnModel> ICollectionService.SaveSTG(SaveStgModel _input)
        {
            string msg = await _unitOfWork.CollectionRepository.SaveSTG(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }
    }
}
