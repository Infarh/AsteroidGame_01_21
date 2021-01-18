using System;

using ConsoleTest.Service;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var decanate = new Decanate();

            var rnd = new Random();

            const int students_count = 100;

            for (var i = 1; i <= students_count; i++)
            {
                var student = new Student
                {
                    Surname = $"Фамилия-{i}",
                    Name = $"Имя-{i}",
                    Patronymic = $"Отчество-{i}",
                    //Ratings = RandomExtensions.GetValues(rnd, rnd.Next(10,21), 2, 6)
                    Ratings = rnd.GetValues(rnd.Next(10, 21), 2, 6)
                };

                decanate.Add(student);
            }

            const string data_file = "students.txt";
            decanate.SaveToFile(data_file);

            var new_decanate = new Decanate();

            new_decanate.LoadFromFile(data_file);
        }
    }
}
