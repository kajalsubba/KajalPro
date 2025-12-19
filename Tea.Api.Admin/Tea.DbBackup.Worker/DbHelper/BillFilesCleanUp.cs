using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.DbBackup.Worker.DbHelper
{
    public static class BillFilesCleanUp
    {
        public async static Task DeleteOldFilesSafe(string Category)
        {
            Log.Information("Bill " + Category + " clean up starts.");

            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var dbSettings = config.GetSection("ConnectionStrings");

            string folderPath = dbSettings["PdfPath"] ?? "";
            folderPath = System.IO.Path.Combine(folderPath, Category);

            if (!Directory.Exists(folderPath))
                return;

            DateTime cutoffDate = DateTime.Now.AddDays(-7);

            foreach (string file in Directory.EnumerateFiles(folderPath))
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(file);

                    if (fileInfo.CreationTime < cutoffDate)
                    {
                        // Use Task.Run to perform file deletion asynchronously
                        await Task.Run(() => fileInfo.Delete());

                        Log.Information("Bill clean up is completed..!");
                    }
                }
                catch (Exception ex)
                {

                    Log.Information("Failed to delete", ex.Message);

                }
            }
        }
    }
}
