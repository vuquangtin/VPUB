using System;
using System.Diagnostics;

namespace CommonLogger.Loggers
{
    internal sealed class SystemEventLogger : ILogger
    {
        public void LogError(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            LogError(ex.ToString());
        }

        public void LogError(string message)
        {
            try
            {
                EventLog.WriteEntry(LogParameters.SourceName, message, EventLogEntryType.Error);
            }
            catch (Exception) { return; }
        }

        public void LogInfo(string info)
        {
            try
            {
                EventLog.WriteEntry(LogParameters.SourceName, info, EventLogEntryType.Information);
            }
            catch (Exception) { return; }
        }
    }
}