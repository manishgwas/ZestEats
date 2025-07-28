using Microsoft.AspNetCore.Mvc;
using PaymentService.Domain;
using PaymentService.Persistence;

namespace PaymentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentsController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        [HttpPost]
        public IActionResult InitiatePayment([FromBody] Payment payment)
        {
            var createdPayment = _paymentRepository.CreatePayment(payment);
            return CreatedAtAction(nameof(GetPaymentStatus), new { orderId = createdPayment.OrderId }, createdPayment);
        }

        [HttpGet("{orderId}")]
        public IActionResult GetPaymentStatus(string orderId)
        {
            var payment = _paymentRepository.GetPaymentByOrderId(orderId);
            if (payment == null) return NotFound();
            return Ok(payment);
        }
    }
}
