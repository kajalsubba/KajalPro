using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.Diagnostics.CodeAnalysis;

namespace Tea.DbBackup.Worker.Helper
{
    public static class EmailSend
    {
        public async static Task MailSendService()
        {
          
            IConfiguration config = new ConfigurationBuilder()
               .SetBasePath(AppContext.BaseDirectory)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .Build();

            var dbSettings = config.GetSection("ConnectionStrings");
            //  string zipPath = dbSettings["ZipPath"] + "TeaDBBackup.zip";         // Output .zip file path
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string zipPath = dbSettings["ZipPath"] + $"TeaDBBackup_{date}.zip";

            string senderEmail = dbSettings["SenderEmail"]??"";
            string appPassword = dbSettings["AppPassword"] ?? ""; 
            string recipientEmail = dbSettings["RecipientEmail"] ?? ""; 
            string subject = "Automatic Database Backup for GLS Portals on " + DateTime.Now.Date.ToString("dd/MM/yyyy");
            string body = "Please donot reyply. Production Database is included.";

            string attachmentPath = zipPath; // Change as needed
            Log.Information("Email sent starts.");

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(recipientEmail);
                mail.Subject = subject;
                mail.Body = body;

                // Add attachment if file exists
                if (File.Exists(attachmentPath))
                {
                    mail.Attachments.Add(new Attachment(attachmentPath));
                }
                else
                {
               
                    Log.Information("Attachment file not found.");

                }

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(senderEmail, appPassword);
                    smtp.EnableSsl = true;

                    await smtp.SendMailAsync(mail);
                    Log.Information("Email sent successfully.");

                }
            }
            catch (Exception ex)
            {
                Log.Information("Error sending email:"+ ex.Message);

            }
        }
    }
}
