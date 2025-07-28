using System;
using System.Threading.Tasks;
using Xunit;
using DeliveryService.Domain;
using DeliveryService.Persistence;
using System.Collections.Generic;

namespace DeliveryService.Tests
{
    public class InMemoryDeliveryRepository : IDeliveryRepository
    {
        private readonly Dictionary<Guid, Delivery> _store = new();
        public Task<Delivery> CreateAsync(Delivery delivery)
        {
            _store[delivery.Id] = delivery;
            return Task.FromResult(delivery);
        }
        public Task<Delivery?> GetByIdAsync(Guid id)
        {
            _store.TryGetValue(id, out var d);
            return Task.FromResult(d);
        }
        public Task UpdateStatusAsync(Guid id, string status)
        {
            if (_store.TryGetValue(id, out var d)) d.Status = status;
            return Task.CompletedTask;
        }
        public Task<IEnumerable<Delivery>> GetStaleDeliveriesAsync()
        {
            return Task.FromResult<IEnumerable<Delivery>>(new List<Delivery>());
        }
    }

    public class DeliveryRepositoryTests
    {
        [Fact]
        public async Task Can_Create_And_Get_Delivery()
        {
            var repo = new InMemoryDeliveryRepository();
            var delivery = new Delivery { Id = Guid.NewGuid(), OrderId = "order456", Address = "456 Main St", Status = "ASSIGNED", AssignedAt = DateTime.UtcNow };
            await repo.CreateAsync(delivery);
            var fetched = await repo.GetByIdAsync(delivery.Id);
            Assert.NotNull(fetched);
            Assert.Equal("order456", fetched.OrderId);
        }
    }
}
