using System;
using System.Collections.Generic;
using OrderService.Domain;

namespace OrderService.Persistence
{
    public interface IOrderRepository
    {
        Order CreateOrder(Order order);
        Order? GetOrderById(Guid id);
    }

    public class OrderRepository : IOrderRepository
    {
        private readonly Dictionary<Guid, Order> _orders = new();

        public Order CreateOrder(Order order)
        {
            _orders[order.Id] = order;
            return order;
        }

        public Order? GetOrderById(Guid id)
        {
            _orders.TryGetValue(id, out var order);
            return order;
        }
    }
}
