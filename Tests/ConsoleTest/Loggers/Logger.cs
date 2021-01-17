using System;

namespace ConsoleTest.Loggers
{
    internal abstract class Logger : ILogger
    {
        void ILogger.TestMethod()
        {
            Console.WriteLine("Тестовый метод");
        }

        public abstract void Log(string Message);

        public void LogInformation(string Message)
        {
            Log($"{DateTime.Now:s}[info]:{Message}");
        }

        public void LogWarning(string Message)
        {
            Log($"{DateTime.Now:s}[warning]:{Message}");
        }

        public void LogError(string Message)
        {
            Log($"{DateTime.Now:s}[error]:{Message}");
        }

        public void LogCritical(string Message)
        {
            Log($"{DateTime.Now:s}[critical]:{Message}");
        }

        public abstract void Flush();
    }
}
