using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DeliveryService.Persistence;

namespace DeliveryService.Infrastructure
{
    public class OrphanDeliveryCleanupService : BackgroundService
    {
        private readonly IDeliveryRepository _repository;
        private readonly ILogger<OrphanDeliveryCleanupService> _logger;
        private readonly TimeSpan _interval = TimeSpan.FromHours(1);

        public OrphanDeliveryCleanupService(IDeliveryRepository repository, ILogger<OrphanDeliveryCleanupService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var stale = await _repository.GetStaleDeliveriesAsync();
                    foreach (var delivery in stale)
                    {
                        await _repository.UpdateStatusAsync(delivery.Id, "FAILED");
                        _logger.LogInformation($"OrphanDeliveryCleanupService: Marked delivery {delivery.Id} as FAILED");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error during orphan delivery cleanup");
                }
                await Task.Delay(_interval, stoppingToken);
            }
        }
    }
}
