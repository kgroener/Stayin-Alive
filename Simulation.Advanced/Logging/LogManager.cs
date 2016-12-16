using Simulation.Interface;
using System;
using System.Threading.Tasks;

namespace Simulation.Logging
{
    internal static class LogManager
    {
        private static Task _disableLoggingTask;

        internal static bool IsInfoEnabled { get; private set; }

        internal static void EnableInfoLogging(TimeSpan infoLogDuration)
        {
            IsInfoEnabled = true;

            if (_disableLoggingTask != null)
            {
                _disableLoggingTask.Dispose();
            }

            _disableLoggingTask = Task.Delay(infoLogDuration).ContinueWith(new Action<Task>((t) => IsInfoEnabled = false));
        }

        internal static ILogger GetLoggerForSpecie(string specieName)
        {
            return new SpecieLogger(specieName);
        }
    }
}
