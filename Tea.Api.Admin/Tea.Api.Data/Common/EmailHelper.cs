using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Data.Common
{
    public static class EmailHelper
    {
        public async static Task<string> SendEmail(string? fromEmail, string? toEmail, string? emailSubject, string? message)
        {
            string senderEmail = fromEmail;
            string appPassword = "eugkezcdbrzkdncc";
            string recipientEmail = toEmail;
            string subject = emailSubject;
            string body = message;

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(senderEmail);
                mail.To.Add(recipientEmail);
                mail.Subject = subject;
                mail.Body = body;

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(senderEmail, appPassword);
                    smtp.EnableSsl = true;

                    await smtp.SendMailAsync(mail);


                }
                return "Email sent successfully!";

            }
            catch (Exception ex)
            {
                return $"Failed to send email: {ex.Message}";
            }
        }
    }
}
