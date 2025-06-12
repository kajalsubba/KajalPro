using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Entity.Accounts;
using Tea.Api.Entity.Common;

namespace Tea.Api.Service.Accounts
{
    public interface IAccountsService
    {

        Task<SaveReturnModel> SaveSeasonAdvance(SaveSeasonAdvanceModel _input);

        Task<DataSet> GetSeasonAdvance(GetSeasonAdvanceModel _input);

        Task<DataSet> GetEntrySeasonAdvance(GetSeasonAdvanceModel _input);
        
        Task<SaveReturnModel> SavePayment(SavePaymentModel _input);
        Task<DataSet> GetPaymentData(GetPaymentModel _input);

        Task<DataSet> GetStgBillData(StgBillModel _input);
        Task<SaveReturnModel> SaveStgBill(SaveStgBill _input);

        Task<DataSet> GetStgBillHistory(GetSTGBillHistoryModel _input);

        Task<DataSet> GetStgSummary(StgSummaryModel _input);

        Task<DataSet> GetSaleSummary(SaleSummaryModel _input);

        Task<DataSet> GetSupplierBillData(SupplierBillModel _input);

        Task<SaveReturnModel> SaveSupplierBill(SaveSupplierBill _input);

        Task<DataSet> GetSupplierBillHistory(GetSupplierBillHistoryModel _input);
        Task<DataSet> GetSupplierSummary(SupplierSummaryModel _input);

        Task<DataSet> GetSmartHistory(SmartHistoryModel _input);

        Task<DataSet> GetNarration(NarrationModel _input);

        Task<SaveReturnModel> SaveUserWallet(WalletModel _input);

        Task<DataSet> GetWalletHistory(WalletHistModel _input);
        Task<DataSet> GetWalletStatement(WalletHistModel _input);


        Task<DataSet> GetWalletBalanace(WalletBalanceModel _input);

        Task<SaveReturnModel> SavePettyCashBook(PettyCashBookModel _input);

        Task<DataSet> GetPettyCashBoook(WalletHistModel _input);
    }
}
