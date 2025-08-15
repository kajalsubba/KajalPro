using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Tea.DbBackup.Worker.DbHelper;
using Tea.DbBackup.Worker.Helper;

Log.Logger = new LoggerConfiguration()
                  .MinimumLevel.Debug()
                  .WriteTo.File("DbBackuplog.txt")
                  .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
                  .CreateLogger();

await ProdBackupHelper.ProdDbBackup();
await DevBackupHelper.DevDbBackup();
await ZipFiles.ZipDbFolder();
await EmailSend.MailSendService();
Log.Information("Backup is Completed");
Console.ReadLine();

