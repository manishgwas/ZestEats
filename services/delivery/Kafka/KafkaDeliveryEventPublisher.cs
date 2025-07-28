using System.Threading.Tasks;
using Confluent.Kafka;
using System.Text.Json;
using DeliveryService.Domain;

namespace DeliveryService.Kafka
{
    public class KafkaDeliveryEventPublisher
    {
        private readonly IProducer<string, string> _producer;
        private readonly string _topic;
        public KafkaDeliveryEventPublisher(string bootstrapServers, string topic)
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

        public async Task PublishEventAsync(Delivery delivery, string eventType)
        {
            var evt = new
            {
                EventType = eventType,
                DeliveryId = delivery.Id,
                OrderId = delivery.OrderId,
                Status = delivery.Status,
                Timestamp = System.DateTime.UtcNow
            };
            var json = JsonSerializer.Serialize(evt);
            await _producer.ProduceAsync(_topic, new Message<string, string> { Key = delivery.Id.ToString(), Value = json });
        }
    }
}
