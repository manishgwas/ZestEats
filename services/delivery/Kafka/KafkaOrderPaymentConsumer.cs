using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using System.Text.Json;

namespace DeliveryService.Kafka
{
    public class KafkaOrderPaymentConsumer
    {
        private readonly IConsumer<string, string> _consumer;
        public KafkaOrderPaymentConsumer(string bootstrapServers, string topic, string groupId)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = bootstrapServers,
                GroupId = groupId,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                SessionTimeoutMs = 10000, // 10s
                MaxPollIntervalMs = 300000, // 5min
                EnableAutoCommit = true,
                EnablePartitionEof = true,
                // MaxPollRecords and FetchMaxWaitMs are not supported in this version
                RetryBackoffMs = 2000 // 2s
            };
            _consumer = new ConsumerBuilder<string, string>(config).Build();
            _consumer.Subscribe(topic);
        }

        public async Task ConsumeAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var cr = _consumer.Consume(cancellationToken);
                // TODO: Parse event and trigger delivery assignment
            }
        }
    }
}
