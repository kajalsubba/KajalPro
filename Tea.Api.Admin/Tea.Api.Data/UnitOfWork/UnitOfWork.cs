﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Data.DbHandler;
using Tea.Api.Data.Repository.Accounts;
using Tea.Api.Data.Repository.Admin;
using Tea.Api.Data.Repository.Collection;

namespace Tea.Api.Data.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly IDataHandler _dataHandler;
        public UnitOfWork(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }

        IAdminRepository? _AdminRepository;

        IAdminRepository IUnitOfWork.AdminRepository => _AdminRepository = new AdminRepository(_dataHandler);


        ICollectionRepository? _CollectionRepository;

        ICollectionRepository IUnitOfWork.CollectionRepository => _CollectionRepository = new CollectionRepository(_dataHandler);

        IAccountsRepository? _AccountsRepository;
        IAccountsRepository IUnitOfWork.AccountsRepository => _AccountsRepository = new AccountsRepository(_dataHandler);

        public void Dispose()
        {
            if (_dataHandler != null)
            {
                GC.SuppressFinalize(this);

            }
        }

       
    }
}
