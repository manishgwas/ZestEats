using Confluent.Kafka;
using System.Text.Json;
using PaymentService.Domain;

namespace PaymentService.Persistence
{
    public interface IPaymentEventPublisher
    {
        Task PublishPaymentEventAsync(Payment payment, string eventType);
    }

    public class KafkaPaymentEventPublisher : IPaymentEventPublisher
    {
        private readonly IProducer<string, string> _producer;
        private readonly string _topic = "payment-events";

        public KafkaPaymentEventPublisher(string bootstrapServers)
        {
            var config = new ProducerConfig { BootstrapServers = bootstrapServers };
            _producer = new ProducerBuilder<string, string>(config).Build();
        }

        public async Task PublishPaymentEventAsync(Payment payment, string eventType)
        {
            var evt = new { EventType = eventType, Payment = payment };
            var message = new Message<string, string>
            {
                Key = payment.Id.ToString(),
                Value = JsonSerializer.Serialize(evt)
            };
            await _producer.ProduceAsync(_topic, message);
        }
    }
}
