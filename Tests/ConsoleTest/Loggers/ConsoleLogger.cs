using System;

namespace ConsoleTest.Loggers
{
    internal class ConsoleLogger : Logger
    {
        public override void Log(string Message)
        {
            Console.WriteLine(Message);
        }

        public override void Flush()
        {
            Console.WriteLine("Все данные логгера сохранены");
        }
    }
}
