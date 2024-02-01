using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Entity.Admin;
using Tea.Api.Entity.Collection;
using Tea.Api.Entity.Common;

namespace Tea.Api.Service.Collection
{
    public interface ICollectionService
    {

        Task<SaveReturnModel> SaveSTG(SaveStgModel _input);

        Task<DataSet> GetStgPendingData(StgFilterModel _input);
    }
}
