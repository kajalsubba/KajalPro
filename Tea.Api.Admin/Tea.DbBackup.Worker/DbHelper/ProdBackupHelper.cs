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
    public static class ProdBackupHelper
    {
        public async static Task ProdDbBackup()
        {
            // Build configuration
            IConfiguration config = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .Build();

            var dbSettings = config.GetSection("ConnectionStrings");

            string databaseName = dbSettings["ProdDatabase"] ?? "";
            Log.Information("PROD DB Database Setup :" + databaseName);
            string backupDirectory = dbSettings["BackupPath"] ?? "";
            string backupFileName = $"{databaseName}_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
            string backupPath = System.IO.Path.Combine(backupDirectory, backupFileName);
            Log.Information("Backup Path :" + backupPath);
            string connectionString = dbSettings["SqlServerConStr"] ?? "";

            Log.Information("Backup starts..");
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
                Log.Information("Backup PROD Database completed successfully File:" + backupPath);
            }
            catch (SqlException ex)
            {
                Log.Error("PROD SQL Error:" + ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error("PROD Error:" + ex.Message);
            }
        }
    }
}
