using System.Threading.Tasks;
using PaymentService.Domain;

namespace PaymentService.Domain
{
    public interface IIdempotencyService
    {
        bool IsDuplicate(string idempotencyKey);
        void Register(string idempotencyKey);
    }

    public class InMemoryIdempotencyService : IIdempotencyService
    {
        private readonly HashSet<string> _keys = new();
        public bool IsDuplicate(string idempotencyKey) => _keys.Contains(idempotencyKey);
        public void Register(string idempotencyKey) => _keys.Add(idempotencyKey);
    }
}
