using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Data.DbHandler;
using Tea.Api.Entity.Collection;

namespace Tea.Api.Data.Repository.Collection
{
    public class CollectionRepository : ICollectionRepository
    {
        readonly IDataHandler _dataHandler;


        public CollectionRepository(IDataHandler dataHandler)
        {

            _dataHandler = dataHandler;
        }
        async Task<string> ICollectionRepository.SaveSTG(SaveStgModel _input)
        {
            throw new NotImplementedException();
        }
    }
}
