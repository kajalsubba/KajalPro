using RabbitMQ.Client;
using Serilog.Events;
using Serilog;
using Tea.RMQ.MessageConsume.ExchangeTypes;
using Microsoft.Extensions.Configuration;

Log.Logger = new LoggerConfiguration()
                  .MinimumLevel.Debug()
                  .WriteTo.File("MQlog.txt")
                  .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
                  .CreateLogger();

// Build configuration
IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

// Retrieve RabbitMQ settings from configuration
var rabbitMqSettings = config.GetSection("RabbitMQ");

var factory = new ConnectionFactory
{
    HostName = rabbitMqSettings["HostName"],    // RabbitMQ server's hostname
    Port = int.Parse(rabbitMqSettings["Port"]), // RabbitMQ port
    UserName = rabbitMqSettings["UserName"],    // RabbitMQ username
    Password = rabbitMqSettings["Password"]     // RabbitMQ password
};

// Create a new connection to the RabbitMQ server
using (var connection = factory.CreateConnection())
{
    // Create a channel within the connection
    using (var channel = connection.CreateModel())
    {
        // Declare a queue to consume messages from
        string queueName = rabbitMqSettings["MessageQueue"]; // Change to your queue name
        channel.QueueDeclare(queue: queueName,
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        DirectExchangeConsumer.consume(channel, rabbitMqSettings["ExchangeTypeName"],
            rabbitMqSettings["MessageQueue"], rabbitMqSettings["Routing"]);
    }
   
}
    