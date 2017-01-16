namespace StayinAlive.Interface.Logging
{
    public interface ILogAppender
    {
        void Info(string logMessage);
        void Error(string logMessage);
    }
}
