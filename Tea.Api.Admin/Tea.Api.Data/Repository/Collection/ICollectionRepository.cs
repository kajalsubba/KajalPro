using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Entity.Collection;
using Tea.Api.Entity.Common;

namespace Tea.Api.Data.Repository.Collection
{
    public interface ICollectionRepository
    {

        Task<string> SaveSTG(SaveStgModel _input);
    }
}
