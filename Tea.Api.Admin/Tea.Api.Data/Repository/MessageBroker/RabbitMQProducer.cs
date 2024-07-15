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
            var factory = new ConnectionFactory
            {
                HostName = "72.167.37.70",    // Replace with your RabbitMQ server's hostname
                Port = 5672,               // Default RabbitMQ port
                UserName = "tea",        // RabbitMQ username
                VirtualHost = "/",
                Password = "TeaGarden@19",         // RabbitMQ password
                ContinuationTimeout = new TimeSpan(10, 0, 0, 0)

            };

            // Create a connection to the RabbitMQ server
            using var connection = factory.CreateConnection();

            // Create a channel
            using var channel = connection.CreateModel();

           var result= DirectExchangeSupplier.Publish(channel, message);
            return result;

        }
    }
}
