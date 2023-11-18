namespace EoS.Logging.Emitting
{
    public sealed class EmittingLoggerEmitter
    {
        public delegate void OnLogEventDelegate(string message);
        private event OnLogEventDelegate? OnLogEvent;

        private List<long> _callers = new();

        public void RegisterEmitterHandler(OnLogEventDelegate handler)
        {
            var handlerHashCode = handler.GetHashCode();

            if (_callers.Contains(handlerHashCode)) return;
            _callers.Add(handlerHashCode);
            OnLogEvent += handler;
        }

        internal void Emit(string message) => OnLogEvent?.Invoke(message);
    }
}
