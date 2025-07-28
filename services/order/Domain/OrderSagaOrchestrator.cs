using System.Threading.Tasks;
using OrderService.Domain;

namespace OrderService.Domain
{
    public interface ISagaOrchestrator
    {
        Task<bool> ExecuteOrderSagaAsync(Order order);
        Task CompensateOrderSagaAsync(Order order);
    }

    public class OrderSagaOrchestrator : ISagaOrchestrator
    {
        public async Task<bool> ExecuteOrderSagaAsync(Order order)
        {
            // Simulate distributed transaction steps (e.g., payment, delivery)
            // In production, use outbox pattern, state store, etc.
            bool paymentSuccess = await TryWithRetryAsync(() => SimulatePayment(order), 3);
            if (!paymentSuccess)
            {
                await CompensateOrderSagaAsync(order);
                return false;
            }
            bool deliverySuccess = await TryWithRetryAsync(() => SimulateDelivery(order), 3);
            if (!deliverySuccess)
            {
                await CompensateOrderSagaAsync(order);
                return false;
            }
            return true;
        }

        public Task CompensateOrderSagaAsync(Order order)
        {
            // Compensate logic (e.g., refund payment, cancel delivery)
            return Task.CompletedTask;
        }

        private async Task<bool> TryWithRetryAsync(Func<Task<bool>> action, int maxRetries)
        {
            int attempts = 0;
            while (attempts < maxRetries)
            {
                if (await action()) return true;
                attempts++;
                await Task.Delay(200 * attempts); // Exponential backoff
            }
            return false;
        }

        private Task<bool> SimulatePayment(Order order) => Task.FromResult(true);
        private Task<bool> SimulateDelivery(Order order) => Task.FromResult(true);
    }
}
