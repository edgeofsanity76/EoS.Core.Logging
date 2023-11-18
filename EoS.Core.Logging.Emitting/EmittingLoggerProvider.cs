using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace EoS.Logging.Emitting
{
    public sealed class EmittingLoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, EmittingLogger> _loggers = new(StringComparer.OrdinalIgnoreCase);
        private readonly EmittingLoggerEmitter _emittingLoggerEmitter;

        public EmittingLoggerProvider(EmittingLoggerEmitter emittingLoggerEmitter) => _emittingLoggerEmitter = emittingLoggerEmitter;
        public ILogger CreateLogger(string categoryName) => _loggers.GetOrAdd(categoryName, name => new EmittingLogger(name, _emittingLoggerEmitter));
        public void Dispose() => _loggers.Clear();
    }
}
