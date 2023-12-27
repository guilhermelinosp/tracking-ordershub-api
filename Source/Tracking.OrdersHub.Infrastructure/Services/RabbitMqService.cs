using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Tracking.OrdersHub.Infrastructure.Messaging;

namespace Tracking.OrdersHub.Infrastructure.Services
{
    public class RabbitMqService : IRabbitMqService
    {
        private readonly IModel _channel;

        public RabbitMqService(IConfiguration configuration)
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = configuration["RabbitMQ_HostName"],
                UserName = configuration["RabbitMQ_UserName"],
                Password = configuration["RabbitMQ_Password"]
            };


            var connection = connectionFactory.CreateConnection("trackings-service-publisher");

            _channel = connection.CreateModel();
        }

        public void Publish(object data, string routingKey)
        {
            var type = data.GetType();

            var payload = JsonConvert.SerializeObject(data);
            var byteArray = Encoding.UTF8.GetBytes(payload);

            Console.WriteLine($"{type.Name} Published");

            _channel.BasicPublish("trackings-service", routingKey, null, byteArray);
        }
    }
}