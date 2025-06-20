using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.RMQ.MessageConsume.Entity;

namespace Tea.RMQ.MessageConsume.Repository
{
    public interface IMQRepository
    {
        Task<string> SaveSupplier(string message);

        Task<string> SaveStg(string message);

        Task<string> TransferStg(string message);
    }
}
