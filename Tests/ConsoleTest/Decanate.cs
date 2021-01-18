using System;
using System.IO;

namespace ConsoleTest
{
    internal class Decanate : Storage<Student>
    {
        private Action<Student> _AddObservers;

        public override void Add(Student item)
        {
            base.Add(item);
            _AddObservers?.Invoke(item);
            //if (_AddObservers != null)
            //    _AddObservers(item);
        }

        public void SubscribeToAdd(Action<Student> Observer)
        {
            _AddObservers += Observer;
        }

        public void UnsubscribeToAdd(Action<Student> Observer)
        {
            _AddObservers -= Observer;
        }

        public override void SaveToFile(string FileName)
        {
            //using (var file_writer = new StreamWriter(new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None)))
            //{

            //}
            using (var file_writer = File.CreateText(FileName))
                foreach (var student in _Items)
                {
                    file_writer.WriteLine(string.Join(",",
                        student.Id, student.Surname, student.Name, student.Patronymic,
                        string.Join(";", student.Ratings)));
                }

        }

        public override void LoadFromFile(string FileName)
        {
            base.LoadFromFile(FileName);

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

                    Add(student);
                }
        }
    }
}
