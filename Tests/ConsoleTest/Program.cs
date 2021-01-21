//using System.Collections;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //CollectionsTest.Run();
        }

        public static IEnumerable<Student> GetStudents(string FileName)
        {
            using (var file_reader = File.OpenText(FileName))
                while (!file_reader.EndOfStream)
                {
                    var str = file_reader.ReadLine();

                    if (string.IsNullOrWhiteSpace(str)) continue;

                    var components = str.Split(',');

                    if (components.Length < 5) continue;

                    var student = new Student
                    {
                        Id = int.Parse(components[0]),
                        Surname = components[1],
                        Name = components[2],
                        Patronymic = components[3]
                    };

                    var ratings = components[4].Split(';');
                    foreach (var rating in ratings)
                        student.Ratings.Add(int.Parse(rating));

                    yield return student;
                }
        }
    }
}
