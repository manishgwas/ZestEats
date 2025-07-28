using Microsoft.AspNetCore.Mvc;
using OrderService.Domain;
using OrderService.Persistence;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderEventPublisher _eventPublisher;
        private readonly ISagaOrchestrator _sagaOrchestrator;

        public OrdersController(IOrderRepository orderRepository, IOrderEventPublisher eventPublisher, ISagaOrchestrator sagaOrchestrator)
        {
            _orderRepository = orderRepository;
            _eventPublisher = eventPublisher;
            _sagaOrchestrator = sagaOrchestrator;
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] Order order)
        {
            // Idempotency: check if order with same key exists
            if (!string.IsNullOrEmpty(order.IdempotencyKey))
            {
                var existing = _orderRepository
                    .GetOrderById(order.Id); // In real prod, use a separate lookup by idempotency key
                if (existing != null && existing.IdempotencyKey == order.IdempotencyKey)
                    return Conflict("Duplicate order");
            }

            var createdOrder = _orderRepository.CreateOrder(order);
            await _eventPublisher.PublishOrderEventAsync(createdOrder, "OrderPlaced");

            // Saga orchestration with retries and compensation
            var sagaResult = await _sagaOrchestrator.ExecuteOrderSagaAsync(createdOrder);
            if (!sagaResult)
            {
                await _eventPublisher.PublishOrderEventAsync(createdOrder, "OrderFailed");
                return StatusCode(500, "Order processing failed and was compensated.");
            }

            return CreatedAtAction(nameof(GetOrderById), new { id = createdOrder.Id }, createdOrder);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(Guid id)
        {
            var order = _orderRepository.GetOrderById(id);
            if (order == null) return NotFound();
            return Ok(order);
        }
    }
}
