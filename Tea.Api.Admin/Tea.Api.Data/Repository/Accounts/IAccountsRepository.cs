using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Entity.Accounts;
using Tea.Api.Entity.Common;

namespace Tea.Api.Data.Repository.Accounts
{
    public interface IAccountsRepository
    {
        Task<string> SaveSeasonAdvance(SaveSeasonAdvanceModel _input);

        Task<DataSet> GetSeasonAdvance(GetSeasonAdvanceModel _input);

        Task<string> SavePayment(SavePaymentModel _input);
        Task<DataSet> GetPaymentData(GetPaymentModel _input);

        Task<DataSet> GetStgBillData(StgBillModel _input);

        Task<string> SaveStgBill(SaveStgBill _input);

        Task<DataSet> GetStgBillHistory(GetSTGBillHistoryModel _input);

        Task<DataSet> GetStgSummary(StgSummaryModel _input);

    }
}
