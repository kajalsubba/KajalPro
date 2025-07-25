using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Entity.Collection;
using Tea.Api.Entity.Common;

namespace Tea.Api.Data.Repository.Collection
{
    public interface ICollectionRepository
    {

        Task<string> SaveSTG(SaveStgModel _input);

        Task<DataSet> GetStgPendingData(StgFilterModel _input);
        Task<DataSet> GetStgBagData(StgBagDataModel _input);
        Task<string> SaveApproveStg(SaveApproveStg _input);

        Task<string> SaveApproveSupplier(SaveApproveSupplier _input);

        Task<string> SaveSale(SaveSaleModel _input);

        Task<DataSet> GetSaleDetails(SelectSale _input);

        Task<string> SaveSupplier(SaveSupplierModel _input);

        Task<string> UploadSupplierChallan(SaveChallanImageModel _input);

        Task<DataSet> GetSupplierDetails(SupplierFilterModel _input);

        Task<DataSet> GetStgRateFixData(GetStgRateFixModel _input);

        Task<string> SaveStgRate(SaveStgRateFixModel _input);
        Task<DataSet> GetSupplierRateFixData(GetSupplierRateFixModel _input);


        Task<string> SaveStgSale(SaveStgSaleModel _input);

        Task<string> LateralStgSave(LateralStgSaveModel _input);

        Task<DataSet> GetSaleRateFixData(GetSaleRateFixModel _input);

        Task<DataSet> GetSupplierVehicle(GetSupplierVehicleModel _input);

        Task<string> SaveSupplierRate(SaveSupplierRateFixModel _input);

        Task<string> SaveSaleRate(SaveSaleRateFixModel _input);

        Task<DataSet> GetStgVehicleData(GetStgVehicleModel _input);

        Task<DataSet> GetStgPendingDate(GetStgPendingDateModel _input);
        Task<DataSet> GetSupplierDefaultData(GetSupplierDefaultModel _input);

        Task<DataSet> GetSaleStgData(GetSaleStgxModel _input);
        Task<DataSet> GetNotifications(NotificationModel _input);
        Task<DataSet> GetSaleSupplierData(GetSaleStgxModel _input);
        Task<DataSet> GetSupplierMobileData(GetSupplierMobileModel _input);
        Task<DataSet> GetSaleFactory(GetSaleFactory _input);
        Task<string> VehicleLockSaveMobile(VehicleLockModel _input);
        Task<DataSet> ClientWiseGradeReport(GradeReportModel _input);

        Task<DataSet> DateWiseGradeReport(GradeReportModel _input);

        Task<DataSet> PurchaseAndSaleReport(GradeReportModel _input);
        Task<DataSet> GetVehicleLockDetails(GetVehicleLockModel _input);
        Task<DataSet> MonthWiseWeightReport(MonthWiseWeightModel _input);
        Task<DataSet> GetLockedVehicleList(LockVehicleListModel _input);
        Task<DataSet> GetTransferStgData(GetStgTransferModel _input);
        Task<DataSet> SalePurchaseWiseReport(GradeReportModel _input);

        Task<string> UpdateTransferStatus(GetStgTransferModel _input);

        Task<DataSet> GetMobileStgData(GetStgHistoryModel _input);

        Task<DataSet> GetSeasonAdvanceReport(SeasonAdvReportModel _input);

        Task<DataSet> GetFieldBalanceReport(SeasonAdvReportModel _input);

        Task<DataSet> GetSaleRateFixFactory(GetSaleRateFixFactory _input);

        Task<DataSet> GetSupplierRateFixFactory(GetSaleRateFixFactory _input);

    }
}
