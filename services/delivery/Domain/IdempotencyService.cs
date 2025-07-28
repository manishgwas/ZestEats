using System.Collections.Concurrent;

namespace DeliveryService.Domain
{
    public class IdempotencyService
    {
        private readonly ConcurrentDictionary<string, bool> _keys = new();
        public bool IsDuplicate(string idempotencyKey)
        {
            return !_keys.TryAdd(idempotencyKey, true);
        }
    }
}
