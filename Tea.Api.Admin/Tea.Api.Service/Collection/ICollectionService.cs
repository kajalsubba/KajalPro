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

        Task<DataSet> GetStgBagData(StgBagDataModel _input);

        Task<SaveReturnModel> SaveApproveStg(SaveApproveStg _input);
        Task<SaveReturnModel> SaveApproveSupplier(SaveApproveSupplier _input);


        Task<SaveReturnModel> SaveSale(SaveSaleModel _input);

        Task<DataSet> GetSaleDetails(SelectSale _input);

        Task<SaveReturnModel> SaveSupplier(SaveSupplierModel _input);

        Task<SaveReturnModel> UploadSupplierChallan(SaveChallanImageModel _input);

        Task<DataSet> GetSupplierDetails(SupplierFilterModel _input);

        Task<DataSet> GetStgRateFixData(GetStgRateFixModel _input);
        Task<DataSet> GetStgRateFixModifyData(GetStgRateFixModel _input);


        Task<DataSet> GetSupplierRateFixData(GetSupplierRateFixModel _input);

        Task<SaveReturnModel> SaveStgRate(SaveStgRateFixModel _input);

        Task<SaveReturnModel> SaveStgSale(SaveStgSaleModel _input);
        Task<SaveReturnModel> LateralStgSave(LateralStgSaveModel _input);
        Task<DataSet> GetSaleRateFixData(GetSaleRateFixModel _input);

        Task<DataSet> GetSupplierVehicle(GetSupplierVehicleModel _input);
        Task<SaveReturnModel> SaveSupplierRate(SaveSupplierRateFixModel _input);

        Task<SaveReturnModel> SaveSaleRate(SaveSaleRateFixModel _input);
        Task<DataSet> GetStgVehicleData(GetStgVehicleModel _input);

        Task<DataSet> GetStgPendingDate(GetStgPendingDateModel _input);

        Task<DataSet> GetSupplierDefaultData(GetSupplierDefaultModel _input);

        Task<DataSet> GetSaleStgData(GetSaleStgxModel _input);
        Task<DataSet> GetSaleSupplierData(GetSaleStgxModel _input);

        Task<DataSet> GetSaleFactory(GetSaleFactory _input);
        Task<DataSet> GetNotifications(NotificationModel _input);

        Task<DataSet> GetSupplierMobileData(GetSupplierMobileModel _input);
        Task<SaveReturnModel> VehicleLockSaveMobile(VehicleLockModel _input);
        Task<DataSet> ClientWiseGradeReport(GradeReportModel _input);
        Task<DataSet> DateWiseGradeReport(GradeReportModel _input);
        Task<DataSet> GetVehicleLockDetails(GetVehicleLockModel _input);
        Task<DataSet> PurchaseAndSaleReport(GradeReportModel _input);
        Task<DataSet> GetLockedVehicleList(LockVehicleListModel _input);
        Task<DataSet> MonthWiseWeightReport(MonthWiseWeightModel _input);
        Task<DataSet> GetTransferStgData(GetStgTransferModel _input);
        Task<SaveReturnModel> UpdateTransferStatus(GetStgTransferModel _input);

        Task<DataSet> SalePurchaseWiseReport(GradeReportModel _input);
        Task<DataSet> GetMobileStgData(GetStgHistoryModel _input);

        Task<DataSet> GetSeasonAdvanceReport(SeasonAdvReportModel _input);

        Task<DataSet> GetFieldBalanceReport(SeasonAdvReportModel _input);
        Task<DataSet> AnalysisReport(AnalysisReportModel _input);
        Task<DataSet> GetSaleRateFixFactory(GetSaleRateFixFactory _input);

        Task<DataSet> GetSupplierRateFixFactory(GetSaleRateFixFactory _input);

        Task<DataSet> GetSupplierHistoryFactory(GetSaleRateFixFactory _input);

        Task<DataSet> GetSupplierHistory(ReportHistoryFilterModel _input);
        Task<DataSet> GetStgRateFixGradeData(GetStgRateFixFilterModel _input);

        Task<DataSet> GetMobileRecoveryVehicle(GetRecoveryVehicleModel _input);
    }
}
