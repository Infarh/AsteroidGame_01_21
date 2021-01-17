using System;
using System.Collections.Generic;

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

            var students = new List<Student>();

            var rnd = new Random();
            for (var i = 1; i <= 10; i++)
            {
                students.Add(new Student
                {
                    Surname = $"Фамилия-{i}",
                    Name = $"Имя-{i}",
                    Rating = rnd.Next(1, 6)
                });
            }

            students.Sort();

            if (!students.Contains(student))
            {
                Console.WriteLine("Журналист отсутствует в списке!");
            }

            //TextFileLogger text_logger = null;
            //try
            //{
            //    text_logger = new TextFileLogger("test2.log");

            //    text_logger.LogInformation("Info!");
            //    text_logger.LogWarning("Warn!");
            //    text_logger.LogError("Err!");
            //}
            //finally
            //{
            //    if (text_logger != null)
            //        text_logger.Dispose();
            //}

            //using (var text_logger = new TextFileLogger("test2.log"))
            //{
            //    text_logger.LogInformation("Info!");
            //    text_logger.LogWarning("Warn!");
            //    text_logger.LogError("Err!");
            //}

            try
            {
                using var text_logger = new TextFileLogger("test2.log");
                text_logger.LogInformation("Info!");
                text_logger.LogWarning("Warn!");
                text_logger.LogError("Err!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            Console.WriteLine("Нажмите Enter для выхода.");
            Console.ReadLine();

            __Logger.LogInformation("Работа приложения завершена");

            __Logger.Flush();
        }
    }
}
