using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Data.DbHandler;
using Tea.Api.Data.Repository.Accounts;
using Tea.Api.Data.Repository.Admin;
using Tea.Api.Data.Repository.Collection;
using Tea.Api.Data.Repository.MessageBroker;
using Tea.Api.Data.Repository.Print;
using Tea.Api.Data.WhatsApp;

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

        IPrintRepository? _PrintRepository;
        IPrintRepository IUnitOfWork.PrintRepository => _PrintRepository = new PrintRepository(_dataHandler);

        IRabitMQProducer? _RabitMQProducer;
        public IRabitMQProducer RabitMQProducer => _RabitMQProducer = new RabbitMQProducer();

        public void Dispose()
        {
            if (_dataHandler != null)
            {
                GC.SuppressFinalize(this);

            }
        }

       
    }
}
