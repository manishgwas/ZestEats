using Grpc.Core;
using OrderService.Grpc;
using OrderService.Domain;
using OrderService.Persistence;

namespace OrderService.GrpcImpl
{
    public class OrderProtoService : OrderProto.OrderProtoBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderProtoService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public override Task<OrderReply> GetOrder(GetOrderRequest request, ServerCallContext context)
        {
            var order = _orderRepository.GetOrderById(Guid.Parse(request.Id));
            if (order == null)
                throw new RpcException(new Status(StatusCode.NotFound, "Order not found"));
            return Task.FromResult(new OrderReply
            {
                Id = order.Id.ToString(),
                UserId = order.UserId,
                Status = order.Status,
                CreatedAt = order.CreatedAt.ToString("o")
            });
        }

        public override Task<OrderReply> PlaceOrder(PlaceOrderRequest request, ServerCallContext context)
        {
            var order = new Order { UserId = request.UserId };
            var createdOrder = _orderRepository.CreateOrder(order);
            return Task.FromResult(new OrderReply
            {
                Id = createdOrder.Id.ToString(),
                UserId = createdOrder.UserId,
                Status = createdOrder.Status,
                CreatedAt = createdOrder.CreatedAt.ToString("o")
            });
        }
    }
}
