using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Data.Repository.Accounts;
using Tea.Api.Data.Repository.Admin;
using Tea.Api.Data.Repository.Collection;

namespace Tea.Api.Data.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IAdminRepository AdminRepository { get; }

        ICollectionRepository CollectionRepository { get; }

        IAccountsRepository AccountsRepository { get; }
    }
}
