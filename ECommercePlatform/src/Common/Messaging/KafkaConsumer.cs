using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace Common.Messaging
{
    public class KafkaConsumer<TKey , TValue>
    {
        private readonly IConsumer<TKey, TValue> _consumer;

        public KafkaConsumer(KafkaSettings settings)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = settings?.BootstrapServers,
                GroupId = settings?.GroupId,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            _consumer = new ConsumerBuilder<TKey, TValue>(config).Build();
        }

        public void StartConsuming(string topic, Func<TValue, Task> handleMessage, CancellationToken cancellationToken)
        {
            _consumer.Subscribe(topic);

            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    var consumeResult = _consumer.Consume(cancellationToken);
                    if (consumeResult?.Message != null)
                    {
                        handleMessage(consumeResult.Message.Value).Wait();
                    }
                }
            }
            catch (OperationCanceledException) { }
            finally
            {
                _consumer.Close();
            }
        }

        public void Dispose() => _consumer.Dispose();   
    }
}