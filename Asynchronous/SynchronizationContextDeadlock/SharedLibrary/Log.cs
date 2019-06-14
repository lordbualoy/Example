using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public abstract class BaseLog
    {
        protected abstract void WriteImplementation(string msg);
        public void Write(string context)
        {
            WriteImplementation($"Method: {context} ThreadId: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
