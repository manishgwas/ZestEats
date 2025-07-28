using System.Threading.Tasks;

namespace DeliveryService.Domain
{
    public class SagaCompensator
    {
        public async Task CompensateDeliveryFailureAsync(string orderId)
        {
            // TODO: Implement compensation logic (e.g., notify order service, revert payment, etc.)
            await Task.CompletedTask;
        }
    }
}
