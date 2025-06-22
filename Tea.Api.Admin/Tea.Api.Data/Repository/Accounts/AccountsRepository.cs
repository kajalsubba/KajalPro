using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Data.Common;
using Tea.Api.Data.DbHandler;
using Tea.Api.Entity.Accounts;
using Tea.Api.Entity.Collection;
using Tea.Api.Entity.Common;

namespace Tea.Api.Data.Repository.Accounts
{

    public class AccountsRepository : IAccountsRepository
    {

        readonly IDataHandler _dataHandler;

        public AccountsRepository(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }

        async Task<DataSet> IAccountsRepository.GetEntrySeasonAdvance(GetSeasonAdvanceModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {

                new ClsParamPair("@FromDate", _input.FromDate ??""),
                new ClsParamPair("@ToDate", _input.ToDate ??""),
                new ClsParamPair("@TenantId", _input.TenantId??0),
                new ClsParamPair("@ClientCategory", _input.ClientCategory ??""),
                new ClsParamPair("@ClientId", _input.ClientId??0)

            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Accounts].[GetSeasonAdvanceEntryData]", oclsPairs);
            ds.Tables[0].TableName = "SeasonDetails";
            return ds;
        }

        async Task<DataSet> IAccountsRepository.GetNarration(NarrationModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@TenantId", _input.TenantId ??0),
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Accounts].[GetNarration]", oclsPairs);
            ds.Tables[0].TableName = "Narration";
            return ds;
        }

        async Task<DataSet> IAccountsRepository.GetPaymentData(GetPaymentModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {

                new ClsParamPair("@FromDate", _input.FromDate ??""),
                new ClsParamPair("@ToDate", _input.ToDate ??""),
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId),
                new ClsParamPair("@ClientCategory", _input.ClientCategory ??""),
                new ClsParamPair("@ClientId", _input.ClientId??0),
                new ClsParamPair("@PaymentTypeId", _input.PaymentTypeId??0),
                new ClsParamPair("@CreatedBy", _input.CreatedBy??0)
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Accounts].[GetPaymentData]", oclsPairs);
            ds.Tables[0].TableName = "PaymentDetails";
            return ds;
        }

        async Task<DataSet> IAccountsRepository.GetPettyCashBoook(WalletHistModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {

                new ClsParamPair("@FromDate", _input.FromDate ??""),
                new ClsParamPair("@ToDate", _input.ToDate ??""),
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId),
                new ClsParamPair("@UserId", _input.UserId??0),
                new ClsParamPair("@CreatedBy", _input.CreatedBy??0)
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Accounts].[GetPettyCashBooktHistoryData]", oclsPairs);
            ds.Tables[0].TableName = "CashBookData";
            return ds;
        }

        async Task<DataSet> IAccountsRepository.GetRecovery(RecoveryFilterRequest _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {

                new ClsParamPair("@FromDate", _input.FromDate ??""),
                new ClsParamPair("@ToDate", _input.ToDate ??""),
                new ClsParamPair("@CategoryId", _input.CategoryId??0),
                new ClsParamPair("@ClientId", _input.ClientId??0),
                new ClsParamPair("@RecovertType", _input.RecovertType??""),
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId),
                new ClsParamPair("@CreatedBy", _input.CreatedBy??0)
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Recovery].[GetRecoveryData]", oclsPairs);
            ds.Tables[0].TableName = "RecoveryDetails";
            return ds;
        }

        async Task<DataSet> IAccountsRepository.GetSaleSummary(SaleSummaryModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@FromDate", _input.FromDate ??""),
                new ClsParamPair("@ToDate", _input.ToDate ??""),
                new ClsParamPair("@TenantId", _input.TenantId??0),
                new ClsParamPair("@FactoryId", _input.FactoryId??0),
                new ClsParamPair("@AccountId", _input.AccountId??0),

            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Summary].[GetSaleSummary]", oclsPairs);
            ds.Tables[0].TableName = "SaleSummary";
            return ds;
        }

        async Task<DataSet> IAccountsRepository.GetSeasonAdvance(GetSeasonAdvanceModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {

                new ClsParamPair("@FromDate", _input.FromDate ??""),
                new ClsParamPair("@ToDate", _input.ToDate ??""),
                new ClsParamPair("@TenantId", _input.TenantId??0),
                new ClsParamPair("@ClientCategory", _input.ClientCategory ??""),
                new ClsParamPair("@ClientId", _input.ClientId??0)

            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Accounts].[GetSeasonAdvanceData]", oclsPairs);
            ds.Tables[0].TableName = "SeasonDetails";
            return ds;
        }

        async Task<DataSet> IAccountsRepository.GetSmartHistory(SmartHistoryModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {

                new ClsParamPair("@FromDate", _input.FromDate ??""),
                new ClsParamPair("@ToDate", _input.ToDate ??""),
                new ClsParamPair("@TenantId", _input.TenantId??0),
                new ClsParamPair("@CategoryName", _input.CategoryName??""),
                new ClsParamPair("@ClientId", _input.ClientId??0)

            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Summary].[SmartHistory]", oclsPairs);
            ds.Tables[0].TableName = "CollectionSummary";
            ds.Tables[1].TableName = "PaymentSummary";
            ds.Tables[2].TableName = "OutstandingSummary";
            return ds;
        }

        async Task<DataSet> IAccountsRepository.GetStgBillData(StgBillModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {

                new ClsParamPair("@FromDate", _input.FromDate ??""),
                new ClsParamPair("@ToDate", _input.ToDate ??""),
                new ClsParamPair("@TenantId", _input.TenantId??0),
                new ClsParamPair("@ClientId", _input.ClientId??0)

            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[TeaCollection].[GetStgBillData]", oclsPairs);
            ds.Tables[0].TableName = "StgData";
            ds.Tables[1].TableName = "PaymentData";
            ds.Tables[2].TableName = "OutStandingData";
            return ds;
        }

        async Task<DataSet> IAccountsRepository.GetStgBillHistory(GetSTGBillHistoryModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {

                new ClsParamPair("@FromDate", _input.FromDate ??""),
                new ClsParamPair("@ToDate", _input.ToDate ??""),
                new ClsParamPair("@TenantId", _input.TenantId??0),
                new ClsParamPair("@ClientId", _input.ClientId??0)

            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Bill].[GetBillHistory]", oclsPairs);
            ds.Tables[0].TableName = "BillHistory";

            return ds;
        }

        async Task<DataSet> IAccountsRepository.GetStgSummary(StgSummaryModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {

                new ClsParamPair("@FromDate", _input.FromDate ??""),
                new ClsParamPair("@ToDate", _input.ToDate ??""),
                new ClsParamPair("@TenantId", _input.TenantId??0),
                new ClsParamPair("@ClientId", _input.ClientId??0)

            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Summary].[GetStgSummary]", oclsPairs);
            ds.Tables[0].TableName = "StgSummary";

            return ds;
        }

        async Task<DataSet> IAccountsRepository.GetSupplierBillData(SupplierBillModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {

                new ClsParamPair("@FromDate", _input.FromDate ??""),
                new ClsParamPair("@ToDate", _input.ToDate ??""),
                new ClsParamPair("@TenantId", _input.TenantId??0),
                new ClsParamPair("@ClientId", _input.ClientId??0)

            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[TeaCollection].[GetSupplierBillData]", oclsPairs);
            ds.Tables[0].TableName = "SupplierData";
            ds.Tables[1].TableName = "PaymentData";
            ds.Tables[2].TableName = "OutStandingData";
            return ds;
        }

        async Task<DataSet> IAccountsRepository.GetSupplierBillHistory(GetSupplierBillHistoryModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {

                new ClsParamPair("@FromDate", _input.FromDate ??""),
                new ClsParamPair("@ToDate", _input.ToDate ??""),
                new ClsParamPair("@TenantId", _input.TenantId??0),
                new ClsParamPair("@ClientId", _input.ClientId??0)

            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Bill].[GetSupplierHistory]", oclsPairs);
            ds.Tables[0].TableName = "BillHistory";

            return ds;
        }

        async Task<DataSet> IAccountsRepository.GetSupplierSummary(SupplierSummaryModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {

                new ClsParamPair("@FromDate", _input.FromDate ??""),
                new ClsParamPair("@ToDate", _input.ToDate ??""),
                new ClsParamPair("@TenantId", _input.TenantId??0),
                new ClsParamPair("@ClientId", _input.ClientId??0)

            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Summary].[GetSupplierSummary]", oclsPairs);
            ds.Tables[0].TableName = "SupplierSummary";

            return ds;
        }

        async Task<DataSet> IAccountsRepository.GetWalletBalanace(WalletBalanceModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId),
                new ClsParamPair("@UserId", _input.UserId??0),
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Accounts].[GetWalletBalanceData]", oclsPairs);
            ds.Tables[0].TableName = "WalletBalance";
            return ds;
        }

        async Task<DataSet> IAccountsRepository.GetWalletHistory(WalletHistModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {

                new ClsParamPair("@FromDate", _input.FromDate ??""),
                new ClsParamPair("@ToDate", _input.ToDate ??""),
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId),
                new ClsParamPair("@UserId", _input.UserId??0),
                new ClsParamPair("@CreatedBy", _input.CreatedBy??0)
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Accounts].[GetWalletHistoryData]", oclsPairs);
            ds.Tables[0].TableName = "WalletHistory";
            return ds;
        }

        async Task<DataSet> IAccountsRepository.GetWalletStatement(WalletHistModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {

                new ClsParamPair("@FromDate", _input.FromDate ??""),
                new ClsParamPair("@ToDate", _input.ToDate ??""),
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId),
                new ClsParamPair("@UserId", _input.UserId??0),
                new ClsParamPair("@CreatedBy", _input.CreatedBy??0)
            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Accounts].[GetWalletStatement]", oclsPairs);
            ds.Tables[0].TableName = "WalletStatement";
            return ds;
        }

        async Task<string> IAccountsRepository.SavePayment(SavePaymentModel _input)
        {
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@PaymentId", _input.PaymentId??0, false, "long"),
                new ClsParamPair("@PaymentDate",Convert.ToDateTime(_input.PaymentDate), true, "DateTime"),
                new ClsParamPair("@BillDate",Convert.ToDateTime(_input.BillDate), true, "DateTime"),
                new ClsParamPair("@ClientCategory",_input.ClientCategory??"", false, "string"),
                new ClsParamPair("@ClientId",_input.ClientId??0, false,"long"),
                new ClsParamPair("@PaymentTypeId",_input.PaymentTypeId??0, false,"long"),
                new ClsParamPair("@Amount", _input.Amount??0, false, "long"),
                new ClsParamPair("@Narration", _input.Narration??"", false, "string"),
                new ClsParamPair("@CategoryId", _input.CategoryId??0, false, "long"),
                new ClsParamPair("@TenantId", _input.TenantId ??0, false, "long"),
                new ClsParamPair("@CreatedBy", _input.CreatedBy ??0, false, "long"),
                new ClsParamPair("@PaymentSource", _input.PaymentSource ??"", false, "string")

            };
            string Msg = await _dataHandler.SaveChangesAsyn("[Accounts].[PaymentInsertUpdate]", oclsPairs);
            return Msg;
        }

        async Task<string> IAccountsRepository.SavePettyCashBook(PettyCashBookModel _input)
        {
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@CashBookId", _input.CashBookId??0, false, "long"),
                new ClsParamPair("@TransactionDate",Convert.ToDateTime(_input.PaymentDate), true, "DateTime"),
                new ClsParamPair("@PaymentTypeId",_input.PaymentTypeId??0, false,"long"),
                new ClsParamPair("@Amount", _input.Amount??0, false, "long"),
                new ClsParamPair("@UserId", _input.UserId ??0, false, "long"),
                new ClsParamPair("@Narration", _input.Narration??"", false, "string"),
                new ClsParamPair("@TenantId", _input.TenantId ??0, false, "long"),
                new ClsParamPair("@CreatedBy", _input.CreatedBy ??0, false, "long"),
            };
            string Msg = await _dataHandler.SaveChangesAsyn("[Accounts].[PettyCashBookInsertUpdate]", oclsPairs);
            return Msg;
        }

        async Task<string> IAccountsRepository.SaveRecovery(SaveRecoveryModel _input)
        {
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@RecoveryDate",Convert.ToDateTime(_input.RecoveryDate), true, "DateTime"),
                new ClsParamPair("@ClientId",_input.ClientId??0, false,"long"),
                new ClsParamPair("@ClientCategory",_input.ClientCategory??"", false,"string"),
                new ClsParamPair("@CategoryId",_input.CategoryId??0, false,"long"),
                new ClsParamPair("@RecoveryType", _input.RecoveryType??"", false, "long"),
                new ClsParamPair("@FieldBalance", _input.FieldBalance??0, false, "long"),
                new ClsParamPair("@Amount", _input.Amount??0, false, "long"),
                new ClsParamPair("@Narration", _input.Narration??"", false, "string"),
                new ClsParamPair("@TenantId", _input.TenantId ??0, false, "long"),
                new ClsParamPair("@CreatedBy", _input.CreatedBy ??0, false, "long"),
            };
            string Msg = await _dataHandler.SaveChangesAsyn("[Recovery].[RecoveryInsertUpdate]", oclsPairs);
            return Msg;
        }

        async Task<string> IAccountsRepository.SaveSeasonAdvance(SaveSeasonAdvanceModel _input)
        {
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@SeasonAdvanceId", _input.SeasonAdvanceId??0, false, "long"),
                new ClsParamPair("@AdvancedDate",Convert.ToDateTime(_input.AdvancedDate), true, "DateTime"),
                new ClsParamPair("@ClientCategory",_input.ClientCategory??"", false, "string"),
                new ClsParamPair("@ClientId",_input.ClientId??0, false,"long"),
                new ClsParamPair("@Amount", _input.Amount??0, false, "long"),
                new ClsParamPair("@Narration", _input.Narration??"", false, "string"),
                new ClsParamPair("@CategoryId", _input.CategoryId??0, false, "long"),
                new ClsParamPair("@TenantId", _input.TenantId??0, false, "long"),
                new ClsParamPair("@CreatedBy", _input.CreatedBy??0, false, "long")
            };
            string Msg = await _dataHandler.SaveChangesAsyn("[Accounts].[SeasonAdvanceInsertUpdate]", oclsPairs);
            return Msg;
        }

        async Task<string> IAccountsRepository.SaveStgBill(SaveStgBill _input)
        {
            List<StgCollectionData> _Stgitems = _input.CollectionData.ToList();
            List<StgPaymentData>? _Paymentitems = _input.PaymentData?.ToList();
            DataTable dt_collection = ConvertToDatatable.ToDataTable(_Stgitems);
            DataTable dt_payment = ConvertToDatatable.ToDataTable(_Paymentitems);
            SqlParameter[] parameters = new SqlParameter[] {
        ParameterCreation.CreateParameter("@BillData", dt_collection, SqlDbType.Structured),
          ParameterCreation.CreateParameter("@PaymentData", dt_payment, SqlDbType.Structured),
            };
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@BillDate",Convert.ToDateTime(_input.BillDate) , true, "Datetime"),
                new ClsParamPair("@FromDate", Convert.ToDateTime(_input.FromDate) , true, "Datetime"),
                new ClsParamPair("@ToDate", Convert.ToDateTime(_input.ToDate), true, "Datetime"),
                new ClsParamPair("@ClientId", _input.ClientId??0, false, "long"),
                new ClsParamPair("@FinalWeight", _input.FinalWeight??0, false, "long"),
                new ClsParamPair("@TotalStgAmount", _input.TotalStgAmount??0, false, "long"),
                new ClsParamPair("@TotalStgPayment", _input.TotalStgPayment??0, false, "long"),
                new ClsParamPair("@PreviousBalance", _input.PreviousBalance??0, false, "long"),
                new ClsParamPair("@StandingSeasonAdv", _input.StandingSeasonAdv??0, false, "long"),
                new ClsParamPair("@Incentive", _input.Incentive??0, false, "long"),
                new ClsParamPair("@Transporting", _input.Transporting??0, false, "long"),
                new ClsParamPair("@GreenLeafCess", _input.GreenLeafCess??0, false, "long"),
                new ClsParamPair("@FinalBillAmount", _input.FinalBillAmount??0, false, "long"),
                new ClsParamPair("@LessSeasonAdv", _input.LessSeasonAdv??0, false, "long"),
                new ClsParamPair("@AmountToPay", _input.AmountToPay??0, false, "long"),
                new ClsParamPair("@PaidAmount", _input.PaidAmount??0, false, "long"),
                new ClsParamPair("@OutstandingAmount", _input.OutstandingAmount??0, false, "long"),
                new ClsParamPair("@TenantId", _input.TenantId ??0, false, "long"),
                new ClsParamPair("@CreatedBy", _input.CreatedBy ??0, false, "long")

            };
            string Msg = await _dataHandler.ExecuteUserTypeTableAsyn("[Bill].[StgBillInsertUpdate]", parameters, oclsPairs);
            return Msg;
        }

        async Task<string> IAccountsRepository.SaveSupplierBill(SaveSupplierBill _input)
        {
            List<SupplierCollectionData>? _Supplieritems = _input.CollectionData?.ToList();
            List<SupplierPaymentData>? _Paymentitems = _input.PaymentData?.ToList();
            DataTable dt_collection = ConvertToDatatable.ToDataTable(_Supplieritems);
            DataTable dt_payment = ConvertToDatatable.ToDataTable(_Paymentitems);
            SqlParameter[] parameters = new SqlParameter[] {
        ParameterCreation.CreateParameter("@BillData", dt_collection, SqlDbType.Structured),
          ParameterCreation.CreateParameter("@PaymentData", dt_payment, SqlDbType.Structured),
            };
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@BillDate",Convert.ToDateTime(_input.BillDate) , true, "Datetime"),
                new ClsParamPair("@FromDate", Convert.ToDateTime(_input.FromDate) , true, "Datetime"),
                new ClsParamPair("@ToDate", Convert.ToDateTime(_input.ToDate), true, "Datetime"),
                new ClsParamPair("@ClientId", _input.ClientId??0, false, "long"),
                new ClsParamPair("@FinalWeight", _input.FinalWeight??0, false, "long"),
                new ClsParamPair("@TotalStgAmount", _input.TotalStgAmount??0, false, "long"),
                new ClsParamPair("@TotalStgPayment", _input.TotalStgPayment??0, false, "long"),
                new ClsParamPair("@PreviousBalance", _input.PreviousBalance??0, false, "long"),
                new ClsParamPair("@StandingSeasonAdv", _input.StandingSeasonAdv??0, false, "long"),
                new ClsParamPair("@LessCommison", _input.Commision??0, false, "long"),
                new ClsParamPair("@GreenLeafCess", _input.GreenLeafCess??0, false, "long"),
                new ClsParamPair("@FinalBillAmount", _input.FinalBillAmount??0, false, "long"),
                new ClsParamPair("@LessSeasonAdv", _input.LessSeasonAdv??0, false, "long"),
                new ClsParamPair("@AmountToPay", _input.AmountToPay??0, false, "long"),
                new ClsParamPair("@TenantId", _input.TenantId ??0, false, "long"),
                new ClsParamPair("@CreatedBy", _input.CreatedBy ??0, false, "long")

            };
            string Msg = await _dataHandler.ExecuteUserTypeTableAsyn("[Bill].[SupplierBillInsertUpdate]", parameters, oclsPairs);
            return Msg;
        }

        async Task<string> IAccountsRepository.SaveUserWallet(WalletModel _input)
        {
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@WalletId", _input.WalletId??0, false, "long"),
                new ClsParamPair("@TransactionDate",Convert.ToDateTime(_input.PaymentDate), true, "DateTime"),
                new ClsParamPair("@Amount",_input.Amount??0, false, "long"),
                new ClsParamPair("@UserId",_input.UserId??0, false, "long"),
                new ClsParamPair("@Narration",_input.Narration??"", false, "String"),
                new ClsParamPair("@TenantId", _input.TenantId??0, false, "long"),
                new ClsParamPair("@CreatedBy", _input.CreatedBy??0, false, "long")
            };
            string Msg = await _dataHandler.SaveChangesAsyn("[Accounts].[WalletInsertUpdate]", oclsPairs);
            return Msg;
        }
    }
}
