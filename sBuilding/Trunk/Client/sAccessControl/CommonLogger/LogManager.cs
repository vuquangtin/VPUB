using CommonLogger.Loggers;
using System;

namespace CommonLogger
{
    public sealed class LogManager
    {
        private static ILogger logger = new SystemEventLogger();
        private const string SourceName = "sParking 6";

        public static void LogError(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            logger.LogError(ex.ToString());
        }

        public static void LogError(string message)
        {
            logger.LogError(message);
        }

        public static void LogInfo(string message)
        {
            logger.LogInfo(message);
        }
    }
}
