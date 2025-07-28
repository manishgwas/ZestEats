using System.Threading.Tasks;
using PaymentService.Domain;

namespace PaymentService.Domain
{
    public interface ITimeoutHandler
    {
        Task<T> ExecuteWithTimeoutAsync<T>(Task<T> task, int timeoutMs);
    }

    public class TimeoutHandler : ITimeoutHandler
    {
        public async Task<T> ExecuteWithTimeoutAsync<T>(Task<T> task, int timeoutMs)
        {
            var timeoutTask = Task.Delay(timeoutMs);
            var completed = await Task.WhenAny(task, timeoutTask);
            if (completed == timeoutTask) throw new TaskCanceledException("Operation timed out");
            return await task;
        }
    }
}
