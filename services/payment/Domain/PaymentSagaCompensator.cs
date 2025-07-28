using System.Threading.Tasks;
using PaymentService.Domain;

namespace PaymentService.Domain
{
    public interface ISagaCompensator
    {
        Task CompensatePaymentAsync(Payment payment);
    }

    public class PaymentSagaCompensator : ISagaCompensator
    {
        public Task CompensatePaymentAsync(Payment payment)
        {
            // Compensate logic (e.g., refund, mark as failed)
            payment.Status = "Failed";
            return Task.CompletedTask;
        }
    }
}
