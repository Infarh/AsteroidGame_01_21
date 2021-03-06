﻿using System.Diagnostics;

namespace ConsoleTest.Loggers
{
    internal class TraceLogger : Logger
    {
        public override void Log(string Message)
        {
            Trace.WriteLine(Message);
        }

        public override void Flush()
        {
            Trace.Flush();
        }
    }
}
