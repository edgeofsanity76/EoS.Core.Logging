using Microsoft.Extensions.Logging;

namespace EoS.Logging.Emitting
{
    /// <summary>
    /// Intercepts log messages and then raises an OnLogEvent event. Useful for displaying log messages in windows or shipping logs to another service
    /// </summary>
    public sealed class EmittingLogger : ILogger
    {
        private readonly string _name;
        private readonly EmittingLoggerEmitter _emittingLoggerEmitter;

        public EmittingLogger(string name, EmittingLoggerEmitter emittingLoggerEmitter) => (_name, _emittingLoggerEmitter) = (name, emittingLoggerEmitter);
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception, string> formatter) => _emittingLoggerEmitter.Emit(($"[{DateTime.UtcNow}][{_name}] {formatter(state, exception!)}"));
        public bool IsEnabled(LogLevel logLevel) => true;
        public IDisposable BeginScope<TState>(TState state) where TState : notnull => default!;
    }

}
