using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeliveryService.Domain;

namespace DeliveryService.Persistence
{
    public interface IDeliveryRepository
    {
        Task<Delivery> CreateAsync(Delivery delivery);
        Task<Delivery?> GetByIdAsync(Guid id);
        Task UpdateStatusAsync(Guid id, string status);
        Task<IEnumerable<Delivery>> GetStaleDeliveriesAsync();
    }
}
