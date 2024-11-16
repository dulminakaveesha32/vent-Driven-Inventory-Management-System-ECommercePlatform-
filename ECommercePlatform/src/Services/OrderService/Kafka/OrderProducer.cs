using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confluent.Kafka;
using Newtonsoft.Json;
using OrderService.Events;

namespace OrderService.Kafka
{
    public class OrderProducer
    {
        private readonly IProducer<string ,string> _producer;
        private readonly string _topicName ;

        public OrderProducer(string bootsrapServices ,string topicName)
        {
            var config= new ProducerConfig { BootstrapServers = bootsrapServices};
            _producer =new ProducerBuilder<string , string >(config).Build();
            _topicName = topicName;
        }
        public async Task PublishOrderCreatedAsync(OrderCreatedEvent orderCreatedEvent)
        {
            var message = new Message<string,string>
            {
                Key = orderCreatedEvent.OrderId.ToString(),
                Value = JsonConvert.SerializeObject(orderCreatedEvent)
            };
            await _producer.ProduceAsync(_topicName , message);
        }
    }
}