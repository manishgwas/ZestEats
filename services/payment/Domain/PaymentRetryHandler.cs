using System;
using System.Threading.Tasks;
using PaymentService.Domain;

namespace PaymentService.Domain
{
    public interface IPaymentRetryHandler
    {
        Task<PaymentResult> ExecuteWithRetryAsync(Func<Task<PaymentResult>> action, int maxRetries = 3);
    }

    public class PaymentRetryHandler : IPaymentRetryHandler
    {
        public async Task<PaymentResult> ExecuteWithRetryAsync(Func<Task<PaymentResult>> action, int maxRetries = 3)
        {
            int attempts = 0;
            PaymentResult? result = null;
            while (attempts < maxRetries)
            {
                result = await action();
                if (result.Success) return result;
                attempts++;
                await Task.Delay(200 * attempts); // Exponential backoff
            }
            return result ?? new PaymentResult { Success = false, FailureReason = "Max retries reached" };
        }
    }
}
