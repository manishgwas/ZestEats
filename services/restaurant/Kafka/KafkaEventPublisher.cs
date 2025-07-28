using Confluent.Kafka;
using System.Text.Json;

namespace Restaurant.Kafka
{
    public class KafkaEventPublisher
    {
        private readonly IProducer<string, string> _producer;
        private readonly string _topic;

        public KafkaEventPublisher(string bootstrapServers, string topic)
        {
            var config = new ProducerConfig {
                BootstrapServers = bootstrapServers,
                MessageTimeoutMs = 10000, // 10s
                Acks = Acks.All,
                EnableIdempotence = true,
                RetryBackoffMs = 2000 // 2s
            };
            _producer = new ProducerBuilder<string, string>(config).Build();
            _topic = topic;
        }

        public async Task PublishAsync<T>(T @event)
        {
            var message = new Message<string, string>
            {
                Key = Guid.NewGuid().ToString(),
                Value = JsonSerializer.Serialize(@event)
            };
            await _producer.ProduceAsync(_topic, message);
        }
    }
}
