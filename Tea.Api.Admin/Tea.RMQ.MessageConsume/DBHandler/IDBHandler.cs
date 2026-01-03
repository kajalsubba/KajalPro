using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.RMQ.MessageConsume.DBHandler
{
    public interface IDBHandler
    {
        Task<string> SaveChangesAsyn(string sProcName, List<ClsParamPair> Param);
        Task<string> ExecuteUserTypeTableAsyn(string sProcName, SqlParameter[] parameters, List<ClsParamPair> Param);


    }
}
