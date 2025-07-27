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
            var config = new ProducerConfig { BootstrapServers = bootstrapServers };
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
