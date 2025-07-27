using Polly;
using Polly.Retry;

namespace Restaurant.Utilities
{
    public static class PollyPolicies
    {
        public static RetryPolicy GetDefaultRetryPolicy()
        {
            return Policy.Handle<Exception>().WaitAndRetry(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }
    }
}
