using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tea.RMQ.MessageConsume.DBHandler;
using Tea.RMQ.MessageConsume.Repository;

namespace Tea.RMQ.MessageConsume.ExchangeTypes
{
    public static class DirectExchangeConsumer
    {
      
        public static void consume(IModel channel,string? ExchangeTypeName,string?
            MsgQueue,string? RountingName)
        {
            channel.ExchangeDeclare(ExchangeTypeName, ExchangeType.Direct);
            // Create a consumer instance

            channel.QueueDeclare(queue: MsgQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);
            channel.QueueBind(MsgQueue, ExchangeTypeName, RountingName);
            var consumer = new EventingBasicConsumer(channel);


            // Define an event handler for receiving messages
            consumer.Received += (sender, e) =>
            {
                // Extract message body
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                // Process the message
                dynamic _data = JsonConvert.DeserializeObject<dynamic>(message)!;
               if(_data.Category!=null)
                {
                    if (_data.Category == "STG")
                    {
                      //  Console.WriteLine(_data.Category);
                        IMQRepository objConsume = new MQRepository();
                        var result = objConsume.SaveStg(message);
                    }
                    else if (_data.Category == "Transfer")
                    {
                        IMQRepository objConsume = new MQRepository();
                        var result = objConsume.TransferStg(message);
                    }
                }
                else
                {
                    IMQRepository objConsume = new MQRepository();
                    var result = objConsume.SaveSupplier(message);
                }



            };

            // Start consuming messages from the specified queue
            channel.BasicConsume(queue: MsgQueue,
                                 autoAck: true, // Set to false if you want to manually acknowledge messages
                                 consumer: consumer);

            // Keep the application running to continue receiving messages
           // Console.WriteLine("start consuming");
            Log.Information("start consuming for PROD");
         
            Console.ReadLine();
        }
    }
}
