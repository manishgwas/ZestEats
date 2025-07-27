using Microsoft.Extensions.Logging;

namespace Shared.Utilities {
    public static class Logger {
        public static ILoggerFactory LoggerFactory { get; } = new LoggerFactory();
        public static ILogger CreateLogger<T>() => LoggerFactory.CreateLogger<T>();
    }
}
