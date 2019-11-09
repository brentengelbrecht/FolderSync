using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderSync
{
    class WindowsEventLog : ILogger
    {
        private String applicationName;

        public WindowsEventLog(String applicationName)
        {
            this.applicationName = applicationName;
        }

        public void LogToError(string message)
        {
            using (EventLog eventLog = new EventLog(applicationName))
            {
                eventLog.Source = applicationName;
                eventLog.WriteEntry(message, EventLogEntryType.Error);
            }
        }

        public void LogToInfo(string message)
        {
            using (EventLog eventLog = new EventLog(applicationName))
            {
                eventLog.Source = applicationName;
                eventLog.WriteEntry(message, EventLogEntryType.Information);
            }
        }

        public void LogToWarning(string message)
        {
            using (EventLog eventLog = new EventLog(applicationName))
            {
                eventLog.Source = applicationName;
                eventLog.WriteEntry(message, EventLogEntryType.Warning);
            }
        }
    }
}
