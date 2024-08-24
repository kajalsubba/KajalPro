using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Tea.Api.Entity.MessageBroker;

namespace Tea.Api.Data.Common
{
    public static class DirectExchangeSupplier
    {

        public static string Publish(IModel channel, SupplierMessageModel message,
             string? ExchangeTypeName, string?
            MsgQueue, string? RountingName)
        {
            var destination = MapSupplierMQ(message);

            channel.ExchangeDeclare(ExchangeTypeName, ExchangeType.Direct);
            // Declare a queue
            string queueName = MsgQueue;  // Replace with your queue name
            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var json = JsonConvert.SerializeObject(destination);

            var body = Encoding.UTF8.GetBytes(json);
            //put the data on to the product queue
            
            channel.BasicPublish(ExchangeTypeName, RountingName, null, body);
            //if (channel.WaitForConfirms(TimeSpan.FromSeconds(5)))
            //{
            return "1,Send Successfully";
        }

        public static string PublishStg(IModel channel, MobileSTGList message,
            string? ExchangeTypeName, string?
           MsgQueue, string? RountingName)
        {
            var destination = message;

            channel.ExchangeDeclare(ExchangeTypeName, ExchangeType.Direct);
            // Declare a queue
            string queueName = MsgQueue;  // Replace with your queue name
            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var json = JsonConvert.SerializeObject(destination);

            var body = Encoding.UTF8.GetBytes(json);
            //put the data on to the product queue

            channel.BasicPublish(ExchangeTypeName, RountingName, null, body);
          
            return "1,Send Successfully";
        }

        public static string PublishStgTransferData(IModel channel, TransferStgDataList message,
           string? ExchangeTypeName, string?
          MsgQueue, string? RountingName)
        {
            var destination = message;

            channel.ExchangeDeclare(ExchangeTypeName, ExchangeType.Direct);
            // Declare a queue
            string queueName = MsgQueue;  // Replace with your queue name
            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var json = JsonConvert.SerializeObject(destination);

            var body = Encoding.UTF8.GetBytes(json);
            //put the data on to the product queue

            channel.BasicPublish(ExchangeTypeName, RountingName, null, body);

            return "1,Send Successfully";
        }


        public static SupplierMQModel MapSupplierMQ(SupplierMessageModel source)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                source.ChallanImage.CopyTo(ms);
                fileBytes = ms.ToArray();
              
            }
            return new SupplierMQModel
            {
                CollectionId = source.CollectionId,
                CollectionDate = source.CollectionDate,
                VehicleNo = source.VehicleNo,
                ClientId = source.ClientId,
                AccountId = source.AccountId,
                FineLeaf = source.FineLeaf,
                ChallanWeight = source.ChallanWeight,
                Rate = source.Rate,
                GrossAmount = source.GrossAmount,
                TripId = source.TripId,
                Status = source.Status,
                Remarks = source.Remarks,
                TenantId = source.TenantId,
                CreatedBy = source.CreatedBy,
                ChallanImage=source.ChallanImage,
                ChallanImageByte = fileBytes
            };
        }
    }
}
