//using System.Collections;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using ConsoleTest.Service;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //CollectionsTest.Run();

            //var groups = new List<Group>(5);
            //for(var i = 1; i < groups.Capacity; i++)
            //    groups.Add(new Group
            //    {
            //        Id = i,
            //        Name = $"Группа-{i}"
            //    });

            //var groups = new List<Group>(5);
            //foreach (var id in Enumerable.Range(1, 5))
            //    groups.Add(new Group
            //    {
            //        Id = id,
            //        Name = $"Группа-{id}"
            //    });

            //var ids = Enumerable.Range(1, 5);
            //var groups_enum = ids.Select(id => new Group
            //{
            //    Id = id,
            //    Name = $"Группа-{id}"
            //});
            //var groups = groups_enum.ToArray();

            var groups = Enumerable
               .Range(1, 5)
               .Select(id => new Group
               {
                   Id = id,
                   Name = $"Группа-{id}"
               })
               .ToArray();

            var rnd = new Random();
            var students = Enumerable
               .Range(1, 200)
               .Select(id => new Student
               {
                   Id = id,
                   Surname = $"Фамилия-{id}",
                   Name = $"Имя-{id}",
                   Patronymic = $"Отчество-{id}",
                   GroupId = rnd.GetValue(groups).Id,
                   Ratings = rnd.GetValues(rnd.Next(5, 21), 1, 6)
               })
               .ToArray();

            var best_students = students
               .Where(student => student.AverageRating > 3.8);

            //var ratings = best_students.Select(
            //    s => new SurnameRating
            //    {
            //        Surname = s.Surname,
            //        Rating = s.AverageRating
            //    })
            //   .ToArray();

            //var ratings = best_students
            //   .Select(s => new { s.Surname, Rating = s.AverageRating })
            //   .ToArray();

            var ratings = best_students
               .Select(s => (s.Surname, Rating: s.AverageRating))
               .ToArray();

            var best_students_count = best_students.Count();

            var last_students_count = students.Count(s => s.AverageRating < 3);

            var max_average_rating = students.Max(s => s.AverageRating);
            var min_average_rating = students.Min(s => s.AverageRating);
            var avg_average_rating = students.Average(s => s.AverageRating);
            var sum_average_rating = students.Sum(s => s.AverageRating);

            var avg_best_students = students
               .Where(s => s.AverageRating > 3.5)
               .Average(s => s.AverageRating);

            var sorted_students = students
               .OrderBy(s => s.AverageRating)
               .ToArray();

            var sorted_students2 = students
               .OrderByDescending(s => s.AverageRating)
               .ToArray();

            var best5_students = sorted_students2.Skip(5).Take(5).ToArray();

            //var group_student = students.Join(
            //    groups,
            //    s => s.GroupId,
            //    g => g.Id,
            //    (student, group) => new
            //    {
            //        Surname = student.Surname,
            //        Name = student.Name,
            //        Patronymic = student.Patronymic,
            //        Rating = student.Ratings,
            //        Group = group.Name
            //    })
            //   .ToArray();

            var group_student = students.Join(
                groups,
                s => s.GroupId,
                g => g.Id,
                (Student, Group) => new { Student, Group })
               .GroupBy(sg => sg.Group.Id)
               .Where(sg => sg.Average(s => s.Student.AverageRating) > 3)
               .ToArray();

            //var students_names = students.ToDictionary(
            //    s => s.Name,
            //    s => s.AverageRating);

            //var student56 = students_names["Имя-56"];

            var text = "Hello World World Hello Hello hello";
            var words = text.Split(' ');
            var words2 = words.Distinct();

            var words_count = words
               .GroupBy(w => w)
               .ToDictionary(g => g.Key, g => g.Count())
               .OrderBy(w => w.Value)
               .ToArray();
        }

        private struct SurnameRating
        {
            public string Surname { get; init; }
            public double Rating { get; init; }
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
                        Patronymic = components[3],
                        GroupId = int.Parse(components[4]),
                    };

                    var ratings = components[5].Split(';');
                    foreach (var rating in ratings)
                        student.Ratings.Add(int.Parse(rating));

                    yield return student;
                }
        }

        public static void WriteStudents(string FileName, IEnumerable<Student> Students)
        {
            using (var file_writer = File.CreateText(FileName))
                foreach (var student in Students)
                {
                    file_writer.WriteLine(string.Join(",",
                        student.Id, student.Surname, student.Name, student.Patronymic,
                        student.GroupId,
                        string.Join(";", student.Ratings)));
                }

        }
    }
}
