using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Tea.Api.Data.WhatsApp
{

    public class WhatsAppService
    {
        readonly IConfiguration _config;
        readonly IConfiguration config = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false).Build();
        public WhatsAppService()
        {
            _config = config;
            TwilioClient.Init
            (
                _config["WhatsApp:AccountSid"],
                _config["WhatsApp:AuthToken"]
            );
        }
        public async Task<string> SendWhatsAppMessageAsync(string? toPhoneNumber, string? message)
        {
            var messageOptions = new CreateMessageOptions(
            new PhoneNumber("whatsapp:+91"+ toPhoneNumber));
            messageOptions.From = new PhoneNumber("whatsapp:+14155238886");
            messageOptions.Body = message;
            var message1 =await MessageResource.CreateAsync(messageOptions);
            return "Success.";
        }

    }
}
