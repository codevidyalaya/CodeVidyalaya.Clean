using CodeVidyalaya.Clean.Application.Contracts.Logging;
using Microsoft.Extensions.Logging;

namespace CodeVidyalaya.Clean.Infrastructure.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        public readonly ILogger<T> loggerFactory;

        public LoggerAdapter(ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory.CreateLogger<T>();
        }

        public void LogInformation(string message, params object[] args)
        {
            loggerFactory.LogInformation(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            loggerFactory.LogWarning(message, args);
        }
    }
}
