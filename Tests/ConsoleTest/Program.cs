using System;
using System.IO;
using System.Linq;
using ConsoleTest.Service;

namespace ConsoleTest
{
    class Program
    {
        private static readonly Random __Random = new Random();

        private static void RateStudent(Student student)
        {
            student.Ratings = __Random.GetValues(__Random.Next(3, 7), 1, 6);
        }

        private static void PrintStudent(Student student)
        {
            Console.WriteLine("Студент:{0}", student);
        }

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

            StorageProcessor<Student> student_processor = RateStudent;
            student_processor += PrintStudent;

            var student_printer = new StudentPrinter("Деканат:");
            decanate.Process(student_printer.Print);

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
