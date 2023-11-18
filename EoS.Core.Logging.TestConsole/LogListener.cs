using EoS.Logging.Emitting;

namespace EoS.Logging.TestConsole;

public class LogListener
{
    public LogListener(EmittingLoggerEmitter emittingLoggerEmitter)
    {
        emittingLoggerEmitter.RegisterEmitterHandler(Listen);
    }

    public void Listen(string message)
    {
        File.AppendAllText("log.txt", message);
    }
}