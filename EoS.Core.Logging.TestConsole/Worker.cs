using Microsoft.Extensions.Logging;

namespace EoS.Logging.TestConsole;

public class Worker(ILogger<Worker> logger)
{
    public void DoWork()
    {
        logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
    }
}