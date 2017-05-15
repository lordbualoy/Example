using System;
using System.Diagnostics;
using _EventLog = System.Diagnostics.EventLog;

namespace EventLog
{
    class Program
    {
        static void Main(string[] args)
        {
            string sSource;
            string sLog;
            string sEvent;

            sSource = "EventLogApp";
            sLog = "Application";
            sEvent = "Hello World";
            if (!_EventLog.SourceExists(sSource))
            {
                _EventLog.CreateEventSource(sSource, sLog);
            }

            _EventLog.WriteEntry(sSource, sEvent);
            _EventLog.WriteEntry(sSource, sEvent,EventLogEntryType.Warning, 234);

            //สามารถดู Log ที่เขียนไว้ได้ใน Event Viewer > Windows Logs > Application (เปลี่ยนตามค่าของ string sLog)
        }
    }
}
