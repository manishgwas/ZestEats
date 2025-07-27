using Confluent.Kafka;
using System.Threading.Tasks;
using CartService.Domain;

namespace CartService
{
    public interface IKafkaPublisher
    {
        Task PublishCartEventAsync(Cart cart, string eventType, string idempotencyKey);
    }

    public class KafkaPublisher : IKafkaPublisher
    {
        private readonly IProducer<string, string> _producer;
        public KafkaPublisher()
        {
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
            _producer = new ProducerBuilder<string, string>(config).Build();
        }
        public async Task PublishCartEventAsync(Cart cart, string eventType, string idempotencyKey)
        {
            var message = $"{{'eventType':'{eventType}','cartId':'{cart.Id}','idempotencyKey':'{idempotencyKey}'}}";
            await _producer.ProduceAsync("cart-events", new Message<string, string> { Key = cart.Id, Value = message });
        }
    }
}
