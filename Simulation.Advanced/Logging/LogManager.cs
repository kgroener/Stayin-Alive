using Simulation.Interface.Logging;
using System.Collections.Concurrent;

namespace Simulation.Logging
{
    public static class LogManager
    {
        private static ConcurrentDictionary<string, ILogger> _loggers;

        public static bool IsInfoEnabled { get; private set; }

        static LogManager()
        {
            _loggers = new ConcurrentDictionary<string, ILogger>();
        }

        public static void DisableInfoLogging()
        {
            IsInfoEnabled = false;
        }

        public static void EnableInfoLogging()
        {
            IsInfoEnabled = true;
        }

        public static ILogger GetLogger(string subject)
        {
            return _loggers.GetOrAdd(subject, (s) => new Logger(s));
        }

        public static ILogger GetLogger(object subject)
        {
            return GetLogger(subject.GetType().Name);
        }
    }
}
