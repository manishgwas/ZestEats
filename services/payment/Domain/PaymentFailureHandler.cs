using PaymentService.Domain;

namespace PaymentService.Domain
{
    public class PaymentFailureHandler
    {
        public void HandleFailure(Payment payment)
        {
            payment.Status = "Failed";
            // Optionally trigger order cancellation event here
        }
    }
}
