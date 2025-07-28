using Grpc.Core;
using PaymentService.Grpc;
using PaymentService.Domain;
using PaymentService.Persistence;

namespace PaymentService.GrpcImpl
{
    public class PaymentProtoService : PaymentProto.PaymentProtoBase
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentProtoService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public override Task<PaymentReply> GetPayment(GetPaymentRequest request, ServerCallContext context)
        {
            var payment = _paymentRepository.GetPaymentByOrderId(request.OrderId);
            if (payment == null)
                throw new RpcException(new Status(StatusCode.NotFound, "Payment not found"));
            return Task.FromResult(new PaymentReply
            {
                Id = payment.Id.ToString(),
                OrderId = payment.OrderId,
                Status = payment.Status,
                CreatedAt = payment.CreatedAt.ToString("o")
            });
        }

        public override Task<PaymentReply> InitiatePayment(InitiatePaymentRequest request, ServerCallContext context)
        {
            var payment = new Payment { OrderId = request.OrderId };
            var createdPayment = _paymentRepository.CreatePayment(payment);
            return Task.FromResult(new PaymentReply
            {
                Id = createdPayment.Id.ToString(),
                OrderId = createdPayment.OrderId,
                Status = createdPayment.Status,
                CreatedAt = createdPayment.CreatedAt.ToString("o")
            });
        }
    }
}
