using EoS.Logging.Emitting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EoS.Logging.TestConsole;

public class Startup
{
    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        //Add services to the collection
        services.AddTransient<Worker>();
        services.AddTransient<LogListener>();
        services.AddLogging(config =>
        {
            config.ClearProviders();
            config.AddEmittingLogger();
        });
        return services.BuildServiceProvider();
    }
}