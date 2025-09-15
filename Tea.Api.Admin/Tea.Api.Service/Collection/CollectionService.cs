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

        async Task<DataSet> ICollectionService.GetNotifications(NotificationModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.GetNotifications(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.GetSaleDetails(SelectSale _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.GetSaleDetails(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.GetSaleFactory(GetSaleFactory _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.GetSaleFactory(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.GetSaleRateFixData(GetSaleRateFixModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.GetSaleRateFixData(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.GetSaleStgData(GetSaleStgxModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.GetSaleStgData(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.GetSaleSupplierData(GetSaleStgxModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.GetSaleSupplierData(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.GetStgPendingData(StgFilterModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.GetStgPendingData(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.GetStgPendingDate(GetStgPendingDateModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.GetStgPendingDate(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.GetStgRateFixData(GetStgRateFixModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.GetStgRateFixData(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.GetStgVehicleData(GetStgVehicleModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.GetStgVehicleData(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.GetSupplierDefaultData(GetSupplierDefaultModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.GetSupplierDefaultData(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.GetSupplierDetails(SupplierFilterModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.GetSupplierDetails(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.GetSupplierMobileData(GetSupplierMobileModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.GetSupplierMobileData(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.GetSupplierRateFixData(GetSupplierRateFixModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.GetSupplierRateFixData(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.GetSupplierVehicle(GetSupplierVehicleModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.GetSupplierVehicle(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.ClientWiseGradeReport(GradeReportModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.ClientWiseGradeReport(_input);
            return ds;
        }

        async Task<SaveReturnModel> ICollectionService.SaveApproveStg(SaveApproveStg _input)
        {
            string msg = await _unitOfWork.CollectionRepository.SaveApproveStg(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }

        async Task<SaveReturnModel> ICollectionService.SaveApproveSupplier(SaveApproveSupplier _input)
        {
            string msg = await _unitOfWork.CollectionRepository.SaveApproveSupplier(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }

        async Task<SaveReturnModel> ICollectionService.SaveSale(SaveSaleModel _input)
        {
            string msg = await _unitOfWork.CollectionRepository.SaveSale(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }

        async Task<SaveReturnModel> ICollectionService.SaveSaleRate(SaveSaleRateFixModel _input)
        {
            string msg = await _unitOfWork.CollectionRepository.SaveSaleRate(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }

        async Task<SaveReturnModel> ICollectionService.SaveSTG(SaveStgModel _input)
        {
            string msg = await _unitOfWork.CollectionRepository.SaveSTG(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }

        async Task<SaveReturnModel> ICollectionService.SaveStgRate(SaveStgRateFixModel _input)
        {
            string msg = await _unitOfWork.CollectionRepository.SaveStgRate(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }

        async Task<SaveReturnModel> ICollectionService.SaveStgSale(SaveStgSaleModel _input)
        {
            string msg = await _unitOfWork.CollectionRepository.SaveStgSale(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }

        async Task<SaveReturnModel> ICollectionService.SaveSupplier(SaveSupplierModel _input)
        {
            string msg = await _unitOfWork.CollectionRepository.SaveSupplier(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }

        async Task<SaveReturnModel> ICollectionService.SaveSupplierRate(SaveSupplierRateFixModel _input)
        {
            string msg = await _unitOfWork.CollectionRepository.SaveSupplierRate(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }

        async Task<SaveReturnModel> ICollectionService.UploadSupplierChallan(SaveChallanImageModel _input)
        {
            string msg = await _unitOfWork.CollectionRepository.UploadSupplierChallan(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }

        async Task<DataSet> ICollectionService.DateWiseGradeReport(GradeReportModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.DateWiseGradeReport(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.PurchaseAndSaleReport(GradeReportModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.PurchaseAndSaleReport(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.MonthWiseWeightReport(MonthWiseWeightModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.MonthWiseWeightReport(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.SalePurchaseWiseReport(GradeReportModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.SalePurchaseWiseReport(_input);
            return ds;
        }

        async Task<SaveReturnModel> ICollectionService.LateralStgSave(LateralStgSaveModel _input)
        {
            string msg = await _unitOfWork.CollectionRepository.LateralStgSave(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }

        async Task<SaveReturnModel> ICollectionService.VehicleLockSaveMobile(VehicleLockModel _input)
        {
            string msg = await _unitOfWork.CollectionRepository.VehicleLockSaveMobile(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }

        async Task<DataSet> ICollectionService.GetVehicleLockDetails(GetVehicleLockModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.GetVehicleLockDetails(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.GetLockedVehicleList(LockVehicleListModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.GetLockedVehicleList(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.GetStgBagData(StgBagDataModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.GetStgBagData(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.GetTransferStgData(GetStgTransferModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.GetTransferStgData(_input);
            return ds;
        }

        async Task<SaveReturnModel> ICollectionService.UpdateTransferStatus(GetStgTransferModel _input)
        {
            string msg = await _unitOfWork.CollectionRepository.UpdateTransferStatus(_input);
            string[] msgList = msg.Split(",");
            return new SaveReturnModel() { Id = Convert.ToInt16(msgList[0]), Message = msgList[1] };
        }

        async Task<DataSet> ICollectionService.GetMobileStgData(GetStgHistoryModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.GetMobileStgData(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.GetSeasonAdvanceReport(SeasonAdvReportModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.GetSeasonAdvanceReport(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.GetFieldBalanceReport(SeasonAdvReportModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.GetFieldBalanceReport(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.GetSaleRateFixFactory(GetSaleRateFixFactory _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.GetSaleRateFixFactory(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.GetSupplierRateFixFactory(GetSaleRateFixFactory _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.GetSupplierRateFixFactory(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.GetSupplierHistoryFactory(GetSaleRateFixFactory _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.GetSupplierHistoryFactory(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.GetSupplierHistory(ReportHistoryFilterModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.GetSupplierHistory(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.GetStgRateFixGradeData(GetStgRateFixFilterModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.GetStgRateFixGradeData(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.GetStgRateFixModifyData(GetStgRateFixModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.GetStgRateFixModifyData(_input);
            return ds;
        }

        async Task<DataSet> ICollectionService.AnalysisReport(AnalysisReportModel _input)
        {
            DataSet ds;
            ds = await _unitOfWork.CollectionRepository.AnalysisReport(_input);
            return ds;
        }
    }
}
