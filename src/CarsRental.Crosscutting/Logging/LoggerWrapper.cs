using System;
using System.Runtime.CompilerServices;
using Serilog;
using Serilog.Events;

namespace CarsRental.Crosscutting.Logging
{
    /// <inheritdoc cref="ILoggerWrapper{TContext}" />
    public class LoggerWrapper<TContext> : ILoggerWrapper<TContext>
    {
        private ILogger _logger;

        public LoggerWrapper()
        {
            _logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.Debug(LogEventLevel.Debug)
                    .WriteTo.File("log.txt", restrictedToMinimumLevel: LogEventLevel.Debug, rollingInterval: RollingInterval.Day, flushToDiskInterval: TimeSpan.FromMilliseconds(100))
                    .CreateLogger();
        }

        /// <inheritdoc cref="ILoggerWrapper{TContext}.Critical(string, Exception, string, object[])" />
        public void Critical(string message, Exception exception = null, [CallerMemberName] string memberName = null, params object[] arguments)
        {
            var formattedMessage = FormatMessage(message, memberName);
            if (exception != null)
            {
                _logger.Fatal(exception, formattedMessage, arguments);
            }
            else
            {
                _logger.Fatal(formattedMessage, arguments);
            }
        }

        /// <inheritdoc cref="ILoggerWrapper{TContext}.Debug(string, string, object[])" />
        public void Debug(string message, [CallerMemberName] string memberName = null, params object[] arguments)
        {
#if DEBUG
            var formattedMessage = FormatMessage(message, memberName);
            _logger.Debug(formattedMessage, arguments);
#endif
        }

        /// <inheritdoc cref="ILoggerWrapper{TContext}.Error(string, Exception, string, object[])" />
        public void Error(string message, Exception exception, [CallerMemberName] string memberName = null, params object[] arguments)
        {
            var formattedMessage = FormatMessage(message, memberName);
            if (exception != null)
            {
                _logger.Error(exception, formattedMessage, arguments);
            }
            else
            {
                _logger.Error(formattedMessage, arguments);
            }
        }

        /// <inheritdoc cref="ILoggerWrapper{TContext}.Information(string, string, object[])" />
        public void Information(string message, [CallerMemberName] string memberName = null, params object[] arguments)
        {
            var formattedMessage = FormatMessage(message, memberName);
            _logger.Information(formattedMessage, arguments);
        }

        /// <inheritdoc cref="ILoggerWrapper{TContext}.Trace(string, string, object[])" />
        public void Trace(string message, [CallerMemberName] string memberName = null, params object[] arguments)
        {
            var formattedMessage = FormatMessage(message, memberName);
            _logger.Verbose(formattedMessage, arguments);
        }

        /// <inheritdoc cref="ILoggerWrapper{TContext}.Warning(string, string, object[])" />
        public void Warning(string message, [CallerMemberName] string memberName = null, params object[] arguments)
        {
            var formattedMessage = FormatMessage(message, memberName);
            _logger.Warning(formattedMessage, arguments);
        }

        private string FormatMessage(string message, string memberName) => $"[{typeof(TContext).FullName}].[{memberName}] {message}";
    }
}
