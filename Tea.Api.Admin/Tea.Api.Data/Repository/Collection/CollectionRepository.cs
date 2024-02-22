using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Data.Common;
using Tea.Api.Data.DbHandler;
using Tea.Api.Entity.Collection;
using Tea.Api.Entity.Common;

namespace Tea.Api.Data.Repository.Collection
{
    public class CollectionRepository : ICollectionRepository
    {
        readonly IDataHandler _dataHandler;

        readonly IConfiguration _config;
        static readonly IConfiguration config = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false).Build();


        public CollectionRepository(IDataHandler dataHandler)
        {

            _dataHandler = dataHandler;
            _config = config;
        }

       async Task<DataSet> ICollectionRepository.GetSaleDetails(SelectSale _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {
             
                new ClsParamPair("@FromDate", _input.FromDate ??""),
                new ClsParamPair("@ToDate", _input.ToDate ??""),
                new ClsParamPair("@VehicleNo", _input.VehicleNo ??""),
                new ClsParamPair("@FactoryId", _input.FactoryId == null ? 0 : _input.FactoryId),
                new ClsParamPair("@AccountId", _input.AccountId == null ? 0 : _input.AccountId),
                new ClsParamPair("@SaleTypeId", _input.SaleTypeId == null ? 0 : _input.SaleTypeId),
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId)

            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Sales].[GetSalesData]", oclsPairs);
            ds.Tables[0].TableName = "SaleDetails";
            return ds;
        }

        async Task<DataSet> ICollectionRepository.GetStgPendingData(StgFilterModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId),
                new ClsParamPair("@FromDate", _input.FromDate ??""),
                new ClsParamPair("@ToDate", _input.ToDate ??""),
                new ClsParamPair("@VehicleNo",_input.VehicleNo??""),
                new ClsParamPair("@Status",_input.Status??""),
                new ClsParamPair("@TripId",_input.TripId == null ? 0 : _input.TripId),
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[TeaCollection].[GetSTGData]", oclsPairs);
            ds.Tables[0].TableName = "STGDetails";
            return ds;
        }

       async Task<string> ICollectionRepository.SaveApproveStg(SaveApproveStg _input)
        {
            List<ApproveStgMapping> _items = _input.ApproveList.ToList();
            DataTable dt = ConvertToDatatable.ToDataTable(_items);
            SqlParameter[] parameters = new SqlParameter[] {
        ParameterCreation.CreateParameter("@ApproveData", dt, SqlDbType.Structured),


    };
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@TotalFirstWeight", _input.TotalFirstWeight == null ? 0 : _input.TotalFirstWeight, false, "long"),
                new ClsParamPair("@TotalWetLeaf", _input.TotalWetLeaf == null ? 0 : _input.TotalWetLeaf, false, "long"),
                new ClsParamPair("@TotalLongLeaf", _input.TotalLongLeaf == null ? "" : _input.TotalLongLeaf, false, "long"),
                new ClsParamPair("@TotalDeduction", _input.TotalDeduction == null ? 0 : _input.TotalDeduction, false, "long"),
                new ClsParamPair("@TotalFinalWeight", _input.TotalFinalWeight == null ? 0 : _input.TotalFinalWeight, false, "long"),
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId, false, "long"),
                new ClsParamPair("@CreatedBy", _input.CreatedBy == null ? 0 : _input.CreatedBy, false, "long")
            };
            string Msg = await _dataHandler.ExecuteUserTypeTableAsyn("[TeaCollection].[STGApproveInsertUpdate]", parameters, oclsPairs);
            return Msg;
        }

      async  Task<string> ICollectionRepository.SaveSale(SaveSaleModel _input)
        {
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@SaleId", _input.SaleId == null ? 0 : _input.SaleId, false, "long"),
                new ClsParamPair("@ApproveId", _input.ApproveId == null ? 0 : _input.ApproveId, false, "long"),
                new ClsParamPair("@SaleDate",Convert.ToDateTime(_input.SaleDate), true,"Datetime"),
                new ClsParamPair("@AccountId", _input.AccountId == null ? 0 : _input.AccountId, false, "long"),
                new ClsParamPair("@VehicleId", _input.VehicleId == null ? 0 : _input.VehicleId, false, "long"),
                new ClsParamPair("@FieldCollectionWeight", _input.FieldCollectionWeight == null ? 0 : _input.FieldCollectionWeight, false, "long"),
                new ClsParamPair("@FineLeaf", _input.FineLeaf == null ? 0 : _input.FineLeaf, false, "long"),
                new ClsParamPair("@ChallanWeight",_input.ChallanWeight == null ? 0 : _input.ChallanWeight, false, "long"),
                new ClsParamPair("@Rate", _input.Rate == null ? 0 : _input.Rate, false, "long"),
                new ClsParamPair("@Incentive", _input.Incentive == null ? 0 : _input.Incentive, false, "long"),
                new ClsParamPair("@GrossAmount", _input.GrossAmount == null ? 0 : _input.GrossAmount, false, "long"),
                new ClsParamPair("@Remarks",_input.Remarks ??"",false,"String"),
                new ClsParamPair("@SaleTypeId",  _input.SaleTypeId == null ? 0 : _input.SaleTypeId, false, "long"),
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId, false, "long"),
                new ClsParamPair("@CreatedBy", _input.CreatedBy == null ? 0 : _input.CreatedBy, false, "long")
            };
            string Msg = await _dataHandler.SaveChangesAsyn("[Sales].[SaleInsertUpdate]", oclsPairs);
            return Msg;
        }

        async Task<string> ICollectionRepository.SaveSTG(SaveStgModel _input)
        {
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@CollectionId", _input.CollectionId == null ? 0 : _input.CollectionId, false, "long"),
                new ClsParamPair("@CollectionDate",Convert.ToDateTime(_input.CollectionDate), true,"Datetime"),
                new ClsParamPair("@VehicleNo", _input.VehicleNo == null ? "" : _input.VehicleNo, false, "string"),
                new ClsParamPair("@ClientId", _input.ClientId == null ? 0 : _input.ClientId, false, "long"),
                new ClsParamPair("@TripId", _input.TripId == null ? 0 : _input.TripId, false, "long"),
                new ClsParamPair("@FirstWeight", _input.FirstWeight == null ? 0 : _input.FirstWeight, false, "long"),
                new ClsParamPair("@WetLeaf", _input.WetLeaf == null ? 0 : _input.WetLeaf, false, "long"),
                new ClsParamPair("@LongLeaf", _input.LongLeaf == null ? 0 : _input.LongLeaf, false, "long"),
                new ClsParamPair("@Deduction",_input.Deduction == null ? 0 : _input.Deduction, false, "long"),
                new ClsParamPair("@FinalWeight", _input.FinalWeight == null ? 0 : _input.FinalWeight, false, "long"),
                new ClsParamPair("@Rate", _input.Rate == null ? 0 : _input.Rate, false, "long"),
                new ClsParamPair("@GrossAmount", _input.GrossAmount == null ? 0 : _input.GrossAmount, false, "long"),
                new ClsParamPair("@GradeId",_input.GradeId == null ? 0 : _input.GradeId, false, "long"),
                new ClsParamPair("@Remarks", _input.Remarks ?? "", false, "String"),
                new ClsParamPair("@Status", _input.Status ?? "", false, "String"),
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId, false, "long"),
                new ClsParamPair("@CreatedBy", _input.CreatedBy == null ? 0 : _input.CreatedBy, false, "long")
            };
            string Msg = await _dataHandler.SaveChangesAsyn("[TeaCollection].[STGInsertUpdate]", oclsPairs);
            return Msg;
        }

     async   Task<string> ICollectionRepository.SaveSupplier(SaveSupplierModel _input)
        {

         //   string ChallanPath = await ClsUploadFile.UploadFile(_config.GetConnectionString("FilePath"), _input.TenantId.ToString(), _input.ChallanImage, "ChallanReciept");

            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@CollectionId", _input.CollectionId == null ? 0 : _input.CollectionId, false, "long"),
                new ClsParamPair("@CollectionDate", Convert.ToDateTime(_input.CollectionDate), true,"Datetime"),
                new ClsParamPair("@VehicleNo",_input.VehicleNo ??"",false,"String"),
                new ClsParamPair("@ClientId", _input.ClientId == null ? 0 : _input.ClientId, false, "long"),
                new ClsParamPair("@AccountId", _input.AccountId == null ? 0 : _input.AccountId, false, "long"),
                new ClsParamPair("@FineLeaf", _input.FineLeaf == null ? 0 : _input.FineLeaf, false, "long"),
                new ClsParamPair("@ChallanWeight", _input.ChallanWeight == null ? 0 : _input.ChallanWeight, false, "long"),
                new ClsParamPair("@Rate",_input.Rate == null ? 0 : _input.Rate, false, "long"),
                new ClsParamPair("@GrossAmount", _input.GrossAmount == null ? 0 : _input.GrossAmount, false, "long"),
                new ClsParamPair("@TripId", _input.TripId == null ? 0 : _input.TripId, false, "long"),
                new ClsParamPair("@Remarks",_input.Remarks ??"",false,"String"),
                new ClsParamPair("@Status",_input.Status ??"",false,"String"),
             //   new ClsParamPair("@ChallanReceiptCopy",ChallanPath ??"",false,"String"),

                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId, false, "long"),
                new ClsParamPair("@CreatedBy", _input.CreatedBy == null ? 0 : _input.CreatedBy, false, "long")
            };
            string Msg = await _dataHandler.SaveChangesAsyn("[TeaCollection].[SupplierInsertUpdate]", oclsPairs);
            return Msg;
        }

       async Task<string> ICollectionRepository.UploadSupplierChallan(SaveChallanImageModel _input)
        {
            string ChallanPath = await ClsUploadFile.UploadFile(_config.GetConnectionString("FilePath"), _input.TenantId.ToString(), _input.ChallanImage, "ChallanReciept"+_input.CollectionId);

            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@CollectionId", _input.CollectionId == null ? 0 : _input.CollectionId, false, "long"),
                new ClsParamPair("@ChallanReceiptCopy",ChallanPath ??"",false,"String")
             
            };
            string Msg = await _dataHandler.SaveChangesAsyn("[TeaCollection].[SupplierChallanUpdate]", oclsPairs);
            return Msg;
        }

       async Task<DataSet> ICollectionRepository.GetSupplierDetails(SupplierFilterModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId),
                new ClsParamPair("@FromDate", _input.FromDate ??""),
                new ClsParamPair("@ToDate", _input.ToDate ??""),
                new ClsParamPair("@VehicleNo",_input.VehicleNo??""),
                new ClsParamPair("@Status",_input.Status??""),
                new ClsParamPair("@TripId",_input.TripId == null ? 0 : _input.TripId),
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[TeaCollection].[GetSupplierData]", oclsPairs);
            ds.Tables[0].TableName = "SupplierDetails";
            return ds;
        }

       async Task<string> ICollectionRepository.SaveApproveSupplier(SaveApproveStg _input)
        {
            List<ApproveStgMapping> _items = _input.ApproveList.ToList();
            DataTable dt = ConvertToDatatable.ToDataTable(_items);
            SqlParameter[] parameters = new SqlParameter[] {
        ParameterCreation.CreateParameter("@ApproveData", dt, SqlDbType.Structured),


    };
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@TotalFirstWeight", _input.TotalFirstWeight == null ? 0 : _input.TotalFirstWeight, false, "long"),
                new ClsParamPair("@TotalWetLeaf", _input.TotalWetLeaf == null ? 0 : _input.TotalWetLeaf, false, "long"),
                new ClsParamPair("@TotalLongLeaf", _input.TotalLongLeaf == null ? "" : _input.TotalLongLeaf, false, "long"),
                new ClsParamPair("@TotalDeduction", _input.TotalDeduction == null ? 0 : _input.TotalDeduction, false, "long"),
                new ClsParamPair("@TotalFinalWeight", _input.TotalFinalWeight == null ? 0 : _input.TotalFinalWeight, false, "long"),
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId, false, "long"),
                new ClsParamPair("@CreatedBy", _input.CreatedBy == null ? 0 : _input.CreatedBy, false, "long")
            };
            string Msg = await _dataHandler.ExecuteUserTypeTableAsyn("[TeaCollection].[SupplierApproveInsertUpdate]", parameters, oclsPairs);
            return Msg;
        }
    }
}
