using StayinAlive.Interface.Logging;
using StayinAlive.Models;
using System;
using System.Collections.Generic;
using System.Composition;

namespace StayinAlive.Logging
{
    internal class Logger : ILogger
    {
        private string _subject;

        [ImportMany]
        internal IEnumerable<ILogAppender> LogAppenders { get; private set; }

        internal Logger(string subject)
        {
            _subject = subject;

            CompositionContainer.Resolve(this);
        }

        public void Error(Func<string> logMessage)
        {
            UseLoggers(l => l.Error(FormatLogMessage(logMessage())));
        }

        public void Error(string logMessage)
        {
            UseLoggers(l => l.Error(FormatLogMessage(logMessage)));

        }

        public void Info(Func<string> logMessage)
        {
            if (LogManager.IsInfoEnabled)
            {
                UseLoggers(l => l.Info(FormatLogMessage(logMessage())));
            }
        }

        public void Info(string logMessage)
        {
            if (LogManager.IsInfoEnabled)
            {
                UseLoggers(l => l.Info(FormatLogMessage(logMessage)));
            }
        }

        private void UseLoggers(Action<ILogAppender> doLog)
        {
            foreach (var logger in LogAppenders)
            {
                doLog(logger);
            }
        }

        private string FormatLogMessage(string message)
        {
            return $"{_subject}: {message}";
        }
    }
}
