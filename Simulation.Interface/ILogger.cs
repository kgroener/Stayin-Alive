using System;

namespace Simulation.Interface
{
    public interface ILogger
    {
        void Info(string logMessage);
        void Info(Func<string> logMessage);
        void Error(string logMessage);
        void Error(Func<string> logMessage);
    }
}
