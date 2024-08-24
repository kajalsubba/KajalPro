using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.Api.Data.Common;
using Tea.Api.Data.DbHandler;
using Tea.Api.Entity.MessageBroker;
using Twilio.TwiML.Messaging;

namespace Tea.Api.Data.Repository.MessageBroker
{
    public class RabbitMQProducer : IRabitMQProducer
    {
      
        readonly IConfiguration _config;
        static readonly IConfiguration config = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false).Build();
        public RabbitMQProducer()
        {
            _config = config;
        }
       async Task<string> IRabitMQProducer.SendProductMessage(SupplierMessageModel  message)
        {
            var rabbitMqSettings = config.GetSection("RabbitMQ");
            var factory = new ConnectionFactory
            {
                HostName = rabbitMqSettings["HostName"],    // RabbitMQ server's hostname
                Port = int.Parse(rabbitMqSettings["Port"]), // RabbitMQ port
                UserName = rabbitMqSettings["UserName"],    // RabbitMQ username
                Password = rabbitMqSettings["Password"]     // RabbitMQ password

            };

            // Create a connection to the RabbitMQ server
            using var connection = factory.CreateConnection();

            // Create a channel
            using var channel = connection.CreateModel();

           var result= DirectExchangeSupplier.Publish(channel, message, rabbitMqSettings["ExchangeTypeName"],
            rabbitMqSettings["MessageQueue"], rabbitMqSettings["Routing"]);
            return result;

        }

       async Task<string> IRabitMQProducer.ProduceStgList(MobileSTGList message)
        {
            var rabbitMqSettings = config.GetSection("RabbitMQ");
            var factory = new ConnectionFactory
            {
                HostName = rabbitMqSettings["HostName"],    // RabbitMQ server's hostname
                Port = int.Parse(rabbitMqSettings["Port"]), // RabbitMQ port
                UserName = rabbitMqSettings["UserName"],    // RabbitMQ username
                Password = rabbitMqSettings["Password"]     // RabbitMQ password

            };

            // Create a connection to the RabbitMQ server
            using var connection = factory.CreateConnection();

            // Create a channel
            using var channel = connection.CreateModel();

            var result = DirectExchangeSupplier.PublishStg(channel, message, rabbitMqSettings["ExchangeTypeName"],
             rabbitMqSettings["MessageQueue"], rabbitMqSettings["Routing"]);
            return result;
        }

      async  Task<string> IRabitMQProducer.TransferSTGData(TransferStgDataList message)
        {
            var rabbitMqSettings = config.GetSection("RabbitMQ");
            var factory = new ConnectionFactory
            {
                HostName = rabbitMqSettings["HostName"],    // RabbitMQ server's hostname
                Port = int.Parse(rabbitMqSettings["Port"]), // RabbitMQ port
                UserName = rabbitMqSettings["UserName"],    // RabbitMQ username
                Password = rabbitMqSettings["Password"]     // RabbitMQ password

            };

            // Create a connection to the RabbitMQ server
            using var connection = factory.CreateConnection();

            // Create a channel
            using var channel = connection.CreateModel();

            var result = DirectExchangeSupplier.PublishStgTransferData(channel, message, rabbitMqSettings["ExchangeTypeName"],
             rabbitMqSettings["MessageQueue"], rabbitMqSettings["Routing"]);
            return result;
        }
    }
}
