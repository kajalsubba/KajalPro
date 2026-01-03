using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.RMQ.MessageConsume.Common
{
    public static class ParameterCreation
    {
        public static SqlParameter CreateParameter(string name, object value, SqlDbType dbType,
 ParameterDirection direction = ParameterDirection.Input, int size = 0)
        {
            return new SqlParameter()
            {
                ParameterName = name,
                SqlDbType = dbType,
                Value = value,
                Direction = direction,
                Size = size
            };
        }

    }
}
