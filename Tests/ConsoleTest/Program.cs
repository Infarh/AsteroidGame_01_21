using System;
using System.IO;
using System.Linq;
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
                    Id = i,
                    Surname = $"Фамилия-{i}",
                    Name = $"Имя-{i}",
                    Patronymic = $"Отчество-{i}",
                    //Ratings = RandomExtensions.GetValues(rnd, rnd.Next(10,21), 2, 6)
                    Ratings = rnd.GetValues(rnd.Next(10, 21), 2, 6)
                };

                decanate.Add(student);
            }

            const string data_file_name = "students.txt";
            decanate.SaveToFile(data_file_name);

            var new_decanate = new Decanate();

            new_decanate.LoadFromFile(data_file_name);

            //foreach (var student in new_decanate)
            //    Console.WriteLine(student);

            var best_students = new_decanate.Where(s => s.AverageRating > 4).ToArray();
            var last_students = new_decanate.Where(s => s.AverageRating < 3).ToArray();

            var data_file = new FileInfo("students.txt");

            foreach (var line in data_file.GetLines())
            {
                if (line.Contains("Отчество-30"))
                {
                    Console.WriteLine(line);
                    break;
                }
            }

        }
    }
}
