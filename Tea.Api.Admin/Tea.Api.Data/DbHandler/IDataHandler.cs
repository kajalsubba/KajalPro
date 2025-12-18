using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Data.DbHandler
{
    public interface IDataHandler
    {
        Task<string> SaveChangesAsyn(string sProcName, List<ClsParamPair> Param);
        Task<DataTable> ExecProcDataTableAsyn(string sProcName);
        Task<DataTable> ExecProcDataTableAsyn(string sProcName, List<ClsParamPair> Param);
        Task<DataSet> ExecProcDataSetAsyn(string sProcName);
        Task<DataSet> ExecProcDataSetAsyn(string sProcName, List<ClsParamPair> Param);
        Task<string> ExecuteUserTypeTableAsyn(string sProcName, SqlParameter[] parameters, List<ClsParamPair> Param);

    }
}
