﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Data.Repository.Accounts;
using Tea.Api.Data.Repository.Admin;
using Tea.Api.Data.Repository.Collection;
using Tea.Api.Data.Repository.MessageBroker;
using Tea.Api.Data.Repository.Print;

namespace Tea.Api.Data.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IAdminRepository AdminRepository { get; }

        ICollectionRepository CollectionRepository { get; }

        IAccountsRepository AccountsRepository { get; }

        IPrintRepository PrintRepository { get; }

        IRabitMQProducer RabitMQProducer { get; }
    }
}
