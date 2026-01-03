using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tea.DbBackup.Worker.Helper
{
    public static class ZipFiles
    {

        public async static Task ZipDbFolder()
        {
           
            IConfiguration config = new ConfigurationBuilder()
               .SetBasePath(AppContext.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .Build();

            var dbSettings = config.GetSection("ConnectionStrings");
            string sourceFolder = dbSettings["BackupPath"] ?? "";
            // string zipPath = dbSettings["ZipPath"] + "TeaDBBackup.zip"; 
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string zipPath = dbSettings["ZipPath"] + $"TeaDBBackup_{date}.zip";

            Log.Information("Folder zipped started.");
            try
            {
                if (File.Exists(zipPath))
                {
                    File.Delete(zipPath); // Overwrite if it exists
                }

                ZipFile.CreateFromDirectory(sourceFolder, zipPath, CompressionLevel.Optimal, includeBaseDirectory: false);
                Log.Information("Folder zipped successfully :" + zipPath);

            }
            catch (Exception ex)
            {
                Log.Error("Zip Error :" + ex.Message);

            }
        }
    }
}
