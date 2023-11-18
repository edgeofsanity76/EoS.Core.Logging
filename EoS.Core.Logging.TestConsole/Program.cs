using Microsoft.Extensions.DependencyInjection;

namespace EoS.Logging.TestConsole;

public class Program
{
    public static void Main(string[] args)
    {
        var serviceProvider = new Startup().ConfigureServices(new ServiceCollection());
        var worker = serviceProvider.GetRequiredService<Worker>();
        serviceProvider.GetRequiredService<LogListener>();

        while (true)
        {
            worker.DoWork();
            Thread.Sleep(1000);
        }
    }
}