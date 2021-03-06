﻿using System.Diagnostics;

namespace ConsoleTest.Loggers
{
    internal class DebugLogger : Logger
    {
        public override void Log(string Message)
        {
            Debug.WriteLine(Message);
        }

        public override void Flush()
        {
            Debug.Flush();
        }
    }
}
