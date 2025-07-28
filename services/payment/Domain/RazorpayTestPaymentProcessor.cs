using System.Threading.Tasks;
using PaymentService.Domain;

namespace PaymentService.Domain
{
    public interface IPaymentProcessor
    {
        Task<PaymentResult> ProcessPaymentAsync(Payment payment);
    }

    public class RazorpayTestPaymentProcessor : IPaymentProcessor
    {
        public async Task<PaymentResult> ProcessPaymentAsync(Payment payment)
        {
            // Simulate Razorpay test mode
            await Task.Delay(200); // Simulate network
            return new PaymentResult { Success = true, PaymentId = "test_razorpay_id" };
        }
    }

    public class PaymentResult
    {
        public bool Success { get; set; }
        public string? PaymentId { get; set; }
        public string? FailureReason { get; set; }
    }
}
