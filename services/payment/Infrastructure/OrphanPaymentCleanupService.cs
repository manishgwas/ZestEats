using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PaymentService.Persistence;

namespace PaymentService.Infrastructure
{
    // Background service to clean up stale/unpaid payments
    public class OrphanPaymentCleanupService : BackgroundService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly ILogger<OrphanPaymentCleanupService> _logger;
        private readonly TimeSpan _cleanupInterval = TimeSpan.FromHours(1); // Run every hour

        public OrphanPaymentCleanupService(IPaymentRepository paymentRepository, ILogger<OrphanPaymentCleanupService> logger)
        {
            _paymentRepository = paymentRepository;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    int cleaned = await _paymentRepository.CleanupStalePaymentsAsync();
                    _logger.LogInformation($"OrphanPaymentCleanupService: Cleaned up {cleaned} stale/unpaid payments at {DateTime.UtcNow}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error during orphan payment cleanup");
                }
                await Task.Delay(_cleanupInterval, stoppingToken);
            }
        }
    }
}
