using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confluent.Kafka;
using InventoryService.Events;
using Newtonsoft.Json;

namespace InventoryService.Kafka
{
    public class InventoryProducer
    {
        private readonly IProducer<string, string> _producer;
        private readonly string _topic;

        public InventoryProducer(string bootstrapServers, string topic)
        {
            var config = new ProducerConfig { BootstrapServers = bootstrapServers };
            _producer = new ProducerBuilder<string, string>(config).Build();
            _topic = topic;
        }

        public async Task PublishInventoryUpdateAsync(InventoryUpdatedEvent inventoryEvent)
        {
            var message = new Message<string, string>
            {
                Key = inventoryEvent.ItemId.ToString(),
                Value = JsonConvert.SerializeObject(inventoryEvent)
            };
            await _producer.ProduceAsync(_topic, message);
        } 
    }
}