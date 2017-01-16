using StayinAlive.Interface.Logging;
using System.Composition;
using System.Diagnostics;

namespace StayinAlive.Logging
{
    [Export(typeof(ILogAppender))]
    public class DebugLogAppender : ILogAppender
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
