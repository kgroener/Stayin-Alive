using System;

namespace Simulation.Interface.Logging
{
    public interface ILogger
    {
        void Info(string logMessage);
        void Info(Func<string> logMessage);
        void Error(string logMessage);
        void Error(Func<string> logMessage);
    }
}
