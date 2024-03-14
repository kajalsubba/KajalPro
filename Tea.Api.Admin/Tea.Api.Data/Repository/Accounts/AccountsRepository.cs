using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Data.DbHandler;
using Tea.Api.Entity.Accounts;

namespace Tea.Api.Data.Repository.Accounts
{

    public class AccountsRepository: IAccountsRepository
    {

        readonly IDataHandler _dataHandler;

        public AccountsRepository(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }

       async Task<DataSet> IAccountsRepository.GetSeasonAdvance(GetSeasonAdvanceModel _input)
        {
            DataSet ds;
            List<ClsParamPair> oclsPairs = new()
            {

                new ClsParamPair("@FromDate", _input.FromDate ??""),
                new ClsParamPair("@ToDate", _input.ToDate ??""),
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId)

            };

            ds = await _dataHandler.ExecProcDataSetAsyn("[Admin].[GetSeasonAdvanceData]", oclsPairs);
            ds.Tables[0].TableName = "SeasonDetails";
            return ds;
        }

        async Task<string> IAccountsRepository.SaveSeasonAdvance(SaveSeasonAdvanceModel _input)
        {
            List<ClsParamPair> oclsPairs = new()
            {
                new ClsParamPair("@SeasonAdvanceId", _input.SeasonAdvanceId??0, false, "long"),
                 new ClsParamPair("@AdvancedDate",Convert.ToDateTime(_input.AdvancedDate), true, "DateTime"),
                new ClsParamPair("@ClientId",_input.ClientId??0, false,"long"),
                new ClsParamPair("@Amount", _input.Amount??0, false, "long"),
                new ClsParamPair("@TenantId", _input.TenantId == null ? 0 : _input.TenantId, false, "long"),
                new ClsParamPair("@CreatedBy", _input.CreatedBy == null ? 0 : _input.CreatedBy, false, "long")
            };
            string Msg = await _dataHandler.SaveChangesAsyn("[Accounts].[SeasonAdvanceInsertUpdate]", oclsPairs);
            return Msg;
        }
    }
}
