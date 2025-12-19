using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.DbBackup.Worker.DbHelper
{
    public static class DevBackupHelper
    {
        public async static Task DevDbBackup()
        {
         
            IConfiguration config = new ConfigurationBuilder()
               .SetBasePath(AppContext.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .Build();


            var dbSettings = config.GetSection("ConnectionStrings");

            string databaseName = dbSettings["DevDatabase"] ?? "";
            Log.Information("DEV Database Setup :" + databaseName);
            string backupDirectory = dbSettings["BackupPath"] ?? "";
            string backupFileName = $"{databaseName+"_DEV"}_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
            string backupPath = System.IO.Path.Combine(backupDirectory, backupFileName);
            Log.Information("Backup Path :" + backupPath);
            string connectionString = dbSettings["SqlServerConStr"] ?? "";

            Log.Information("DEV DB Backup starts..");
            string backupSql = $@"
            BACKUP DATABASE [{databaseName}]
            TO DISK = N'{backupPath}'
            WITH FORMAT,
                 INIT,
                 NAME = N'{databaseName}-Full Database Backup',
                 SKIP, NOREWIND, NOUNLOAD, STATS = 10;";

            using SqlConnection connection = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand(backupSql, connection);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Log.Information("Backup DEV Database completed successfully File:" + backupPath);
            }
            catch (SqlException ex)
            {
                Log.Error("DEV SQL Error:" + ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error("DEV Error:" + ex.Message);
            }
        }
    }
}
