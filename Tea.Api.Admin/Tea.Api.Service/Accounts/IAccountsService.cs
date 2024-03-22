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

        Task<SaveReturnModel> SavePayment(SavePaymentModel _input);
        Task<DataSet> GetPaymentData( GetPaymentModel _input);

        Task<DataSet> GetStgBillData( StgBillModel _input);
        Task<SaveReturnModel> SaveStgBill(SaveStgBill _input);

    }
}
