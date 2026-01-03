using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.RMQ.MessageConsume.DBHandler
{
    public sealed class DBConnect
    {
        readonly IConfiguration _config;
        static readonly Lazy<DBConnect> instance = new(() => new DBConnect());
        readonly IConfiguration config = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false).Build();
        private DBConnect()
        {
            _config = config;

        }
        public static DBConnect ConnObject
        {
            get
            {
                return instance.Value;
            }
        }

        public SqlConnection SqlSvrConnection()
        {

            SqlConnection scon = new(_config.GetConnectionString("SqlServerConStr"));
            try
            {

                return scon;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                scon.Close();
                SqlConnection.ClearPool(scon);

            }

        }

    }
}
