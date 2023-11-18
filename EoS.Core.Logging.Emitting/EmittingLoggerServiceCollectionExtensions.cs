using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;


namespace EoS.Logging.Emitting
{
    public static class EmittingLoggerServiceCollectionExtensions
    {
        public static ILoggingBuilder AddEmittingLogger(this ILoggingBuilder builder)
        {
            builder.AddConfiguration();
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, EmittingLoggerProvider>());
            builder.Services.AddSingleton<EmittingLoggerEmitter>();
            return builder;
        }
    }
}
