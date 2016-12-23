using Simulation.Interface.Logging;
using System.Composition;
using System.Diagnostics;

namespace Simulation.Logging
{
    [Export(typeof(ILogAppender))]
    public class DebugLogger : ILogAppender
    {
        public void Error(string logMessage)
        {
            Debug.WriteLine(logMessage);

        }

        public void Info(string logMessage)
        {
            Debug.WriteLine(logMessage);
        }
    }
}
