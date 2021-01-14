using System;
using ConsoleTest.Loggers;

namespace ConsoleTest
{
    class Program
    {
        private static int _X = 5;
        private static int _Y = 0;
        private static ILogger __Logger;

        static void Main(string[] args)
        {
            var student = new Student
            {
                Surname = "Иванов",
                Name = "Иван"
            };

            Console.WriteLine(student);

            //__Logger = new TextFileLogger("test.log");
            //__Logger = new ConsoleLogger();
            //__Logger = new CombineLogger(new ConsoleLogger(), new TextFileLogger("test.log"));
            __Logger = student;


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
