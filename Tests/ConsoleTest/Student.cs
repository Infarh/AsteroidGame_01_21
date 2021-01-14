using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Student : ILogger
    {
        public string Name { get; init; }

        public string Surname { get; init; }

        public override string ToString() => $"{Surname} {Name}";

        public void TestMethod() => Console.WriteLine("Я {0}", this);

        public void Log(string Message) => Console.WriteLine("{0}: {1}", this, Message);

        public void LogInformation(string Message) => Log($"{DateTime.Now:s}[info]:{Message}");
        public void LogWarning(string Message) => Log($"{DateTime.Now:s}[warning]:{Message}");
        public void LogError(string Message) => Log($"{DateTime.Now:s}[error]:{Message}");
        public void LogCritical(string Message) => Log($"{DateTime.Now:s}[critical]:{Message}");

        public void Flush() => Console.WriteLine("{0} работу закончил!", this);
    }
}
