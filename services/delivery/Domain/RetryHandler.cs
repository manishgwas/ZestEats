using System;
using System.Threading.Tasks;

namespace DeliveryService.Domain
{
    public class RetryHandler
    {
        public async Task ExecuteWithRetryAsync(Func<Task> action, int maxRetries = 3, int delayMs = 500)
        {
            int attempt = 0;
            while (true)
            {
                try
                {
                    await action();
                    break;
                }
                catch
                {
                    attempt++;
                    if (attempt >= maxRetries) throw;
                    await Task.Delay(delayMs);
                }
            }
        }
    }
}
