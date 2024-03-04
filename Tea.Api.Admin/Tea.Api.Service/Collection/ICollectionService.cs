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

        Task<SaveReturnModel> SaveApproveStg(SaveApproveStg _input);
        Task<SaveReturnModel> SaveApproveSupplier(SaveApproveSupplier _input);
        

        Task<SaveReturnModel> SaveSale(SaveSaleModel _input);

        Task<DataSet> GetSaleDetails(SelectSale _input);

        Task<SaveReturnModel> SaveSupplier(SaveSupplierModel _input);

        Task<SaveReturnModel> UploadSupplierChallan( SaveChallanImageModel _input);

        Task<DataSet> GetSupplierDetails(SupplierFilterModel _input);

        Task<DataSet> GetStgRateFixData(GetStgRateFixModel _input);

        Task<SaveReturnModel> SaveStgRate(SaveStgRateFixModel _input);
        
    }
}
