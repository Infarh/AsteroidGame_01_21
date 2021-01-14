using System;
using ConsoleTest.Loggers;

namespace ConsoleTest
{
    class Program
    {
        private static int _X = 5;
        private static int _Y = 0;
        private static Logger __Logger;

        static void Main(string[] args)
        {
            __Logger = new TextFileLogger("test.log");

            __Logger.LogInformation("Приложение запущено");

            try
            {
                var z = _X / _Y;
            }
            catch (DivideByZeroException)
            {
                __Logger.LogError($"Ошибка при делении {_X} на 0");
            }

            Console.WriteLine("Нажмите Enter для выхода.");
            Console.ReadLine();

            __Logger.LogInformation("Работа приложения завершена");

            __Logger.Flush();
        }
    }
}
