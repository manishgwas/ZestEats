using System;
using System.Collections.Generic;
using PaymentService.Domain;

namespace PaymentService.Persistence
{
    public interface IPaymentRepository
    {
        Payment CreatePayment(Payment payment);
        Payment? GetPaymentByOrderId(string orderId);
        /// <summary>
        /// Cleans up stale/unpaid payments. Returns the number of records cleaned.
        /// </summary>
        Task<int> CleanupStalePaymentsAsync();
    }

    public class PaymentRepository : IPaymentRepository
    {
        private readonly Dictionary<string, Payment> _payments = new();

        public Payment CreatePayment(Payment payment)
        {
            _payments[payment.OrderId] = payment;
            return payment;
        }

        public Payment? GetPaymentByOrderId(string orderId)
        {
            _payments.TryGetValue(orderId, out var payment);
            return payment;
        }

        public Task<int> CleanupStalePaymentsAsync()
        {
            // Remove payments older than 1 day and not completed
            var now = DateTime.UtcNow;
            var toRemove = new List<string>();
            foreach (var kv in _payments)
            {
                if (kv.Value.Status != "COMPLETED" && (now - kv.Value.CreatedAt).TotalHours > 24)
                {
                    toRemove.Add(kv.Key);
                }
            }
            foreach (var key in toRemove)
                _payments.Remove(key);
            return Task.FromResult(toRemove.Count);
        }
    }
}
