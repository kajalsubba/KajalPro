using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.RMQ.MessageConsume.DBHandler
{
    public interface IDBHandler
    {
        Task<string> SaveChangesAsyn(string sProcName, List<ClsParamPair> Param);

    }
}
