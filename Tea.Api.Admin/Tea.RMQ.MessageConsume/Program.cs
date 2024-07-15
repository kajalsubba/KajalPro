

using RabbitMQ.Client;
using Serilog.Events;
using Serilog;
using Tea.RMQ.MessageConsume.ExchangeTypes;
using Newtonsoft.Json;
using Tea.RMQ.MessageConsume.Entity;

Log.Logger = new LoggerConfiguration()
                  .MinimumLevel.Debug()
                  .WriteTo.File("MQlog.txt")
                  .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
                  .CreateLogger();


//string ddd = "{{\r\n  \"ContentDisposition\": \"form-data; name=\\\"ChallanImage\\\"; filename=\\\"fligt tivkrts.pdf\\\"\",\r\n  \"ContentType\": \"application/pdf\",\r\n  \"Headers\": {\r\n    \"Content-Disposition\": [\r\n      \"form-data; name=\\\"ChallanImage\\\"; filename=\\\"fligt tivkrts.pdf\\\"\"\r\n    ],\r\n    \"Content-Type\": [\r\n      \"application/pdf\"\r\n    ]\r\n  },\r\n  \"Length\": 90071,\r\n  \"Name\": \"ChallanImage\",\r\n  \"FileName\": \"fligt tivkrts.pdf\"\r\n}}";
//try
//{
//    var fileModel = JsonConvert.DeserializeObject<FileModel>(ddd);
//    //   var fileModel = deserializedObject["ChallanImage"];

//    byte[] fileContents = new byte[fileModel.Length]; // Replace with actual content
//}
//catch(Exception ex)
//{
//    throw ex;
//}

var factory = new ConnectionFactory
{
    HostName = "72.167.37.70",    // Replace with your RabbitMQ server's hostname
    Port = 5672,               // Default RabbitMQ port
    UserName = "tea",        // RabbitMQ username
  //  VirtualHost = "/",
    Password = "TeaGarden@19",         // RabbitMQ password
   // ContinuationTimeout = new TimeSpan(10, 0, 0, 0)
};

// Create a new connection to the RabbitMQ server
using (var connection = factory.CreateConnection())
{
    // Create a channel within the connection
    using (var channel = connection.CreateModel())
    {
        // Declare a queue to consume messages from
        string queueName = "Supplier"; // Change to your queue name
        channel.QueueDeclare(queue: queueName,
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        DirectExchangeConsumer.consume(channel);
    }
   
}
    