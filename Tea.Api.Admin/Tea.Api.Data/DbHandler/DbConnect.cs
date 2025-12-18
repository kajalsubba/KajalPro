using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Data.DbHandler
{
    public sealed class DbConnect
    {

        readonly IConfiguration _config;
        static readonly Lazy<DbConnect> instance = new(() => new DbConnect());
        readonly IConfiguration config = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false).Build();
        private DbConnect()
        {
            _config = config;

        }
        public static DbConnect ConnObject
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
