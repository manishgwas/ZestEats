using Confluent.Kafka;
using System.Threading.Tasks;
using MenuService.Domain;

namespace MenuService
{
    public interface IKafkaPublisher
    {
        Task PublishMenuEventAsync(Menu menu, string eventType, string idempotencyKey);
    }

    public class KafkaPublisher : IKafkaPublisher
    {
        private readonly IProducer<string, string> _producer;
        public KafkaPublisher()
        {
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
            _producer = new ProducerBuilder<string, string>(config).Build();
        }
        public async Task PublishMenuEventAsync(Menu menu, string eventType, string idempotencyKey)
        {
            var message = $"{{'eventType':'{eventType}','menuId':'{menu.Id}','idempotencyKey':'{idempotencyKey}'}}";
            await _producer.ProduceAsync("menu-events", new Message<string, string> { Key = menu.Id, Value = message });
        }
    }
}
