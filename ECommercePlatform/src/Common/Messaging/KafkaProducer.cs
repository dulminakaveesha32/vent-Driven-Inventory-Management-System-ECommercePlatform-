using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace Common.Messaging
{
    public class KafkaProducer<TKey ,TValue>
    {
        private readonly IProducer<TKey , TValue> _producer;
        public KafkaProducer(KafkaSettings settings)
        {
            var config = new ProducerConfig { BootstrapServers = settings?.BootstrapServers };
            _producer = new ProducerBuilder<TKey, TValue>(config).Build();
        }
        public async Task ProduceAsync(string topic, TKey key, TValue value)
        {
            try
            {
                var message = new Message<TKey, TValue> { Key = key, Value = value };
                await _producer.ProduceAsync(topic, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error producing message: {ex.Message}");
            }
        }

        public void Dispose() => _producer.Dispose();
    }
}