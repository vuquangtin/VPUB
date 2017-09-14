using System;

namespace CommonLogger
{
    public interface ILogger
    {
        void LogError(Exception ex);
        void LogError(string message);
        void LogInfo(string message);
    }
}