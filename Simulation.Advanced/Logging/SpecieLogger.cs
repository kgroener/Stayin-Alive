using Simulation.Interface;
using System;
using System.Diagnostics;

namespace Simulation.Logging
{
    public class SpecieLogger : ILogger
    {
        private string _specieName;

        public SpecieLogger(string specieName)
        {
            _specieName = specieName;
        }

        public void Error(Func<string> logMessage)
        {
            Debug.WriteLine(FormatLogMessage(logMessage()));
        }

        public void Error(string logMessage)
        {
            Debug.WriteLine(FormatLogMessage(logMessage));

        }

        public void Info(Func<string> logMessage)
        {
            if (LogManager.IsInfoEnabled)
            {
                Debug.WriteLine(FormatLogMessage(logMessage()));
            }

        }

        public void Info(string logMessage)
        {
            if (LogManager.IsInfoEnabled)
            {
                Debug.WriteLine(FormatLogMessage(logMessage));
            }
        }

        private string FormatLogMessage(string message)
        {
            return $"{_specieName}: message";
        }
    }
}
