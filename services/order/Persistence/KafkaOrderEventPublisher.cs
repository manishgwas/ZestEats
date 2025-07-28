using Confluent.Kafka;
using System.Text.Json;
using OrderService.Domain;

namespace OrderService.Persistence
{
    public interface IOrderEventPublisher
    {
        Task PublishOrderEventAsync(Order order, string eventType);
    }

    public class KafkaOrderEventPublisher : IOrderEventPublisher
    {
        private readonly IProducer<string, string> _producer;
        private readonly string _topic = "order-events";

        public KafkaOrderEventPublisher(string bootstrapServers)
        {
            var config = new ProducerConfig { BootstrapServers = bootstrapServers };
            _producer = new ProducerBuilder<string, string>(config).Build();
        }

        public async Task PublishOrderEventAsync(Order order, string eventType)
        {
            var evt = new { EventType = eventType, Order = order };
            var message = new Message<string, string>
            {
                Key = order.Id.ToString(),
                Value = JsonSerializer.Serialize(evt)
            };
            await _producer.ProduceAsync(_topic, message);
        }
    }
}
