using System;

namespace ConsoleTest
{
    class Student : ILogger, IComparable, IEquatable<Student>, ICloneable
    {
        public string Name { get; init; }

        public string Surname { get; init; }

        public double Rating { get; set; }

        public override string ToString() => $"{Surname} {Name}";

        void ILogger.TestMethod() => Console.WriteLine("Я {0}", this);

        void ILogger.Log(string Message) => Console.WriteLine("{0}: {1}", this, Message);

        void ILogger.LogInformation(string Message) => ((ILogger)this).Log($"{DateTime.Now:s}[info]:{Message}");
        void ILogger.LogWarning(string Message) => ((ILogger)this).Log($"{DateTime.Now:s}[warning]:{Message}");
        void ILogger.LogError(string Message) => ((ILogger)this).Log($"{DateTime.Now:s}[error]:{Message}");
        void ILogger.LogCritical(string Message) => ((ILogger)this).Log($"{DateTime.Now:s}[critical]:{Message}");

        void ILogger.Flush() => Console.WriteLine("{0} работу закончил!", this);

        public int CompareTo(object obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (obj is Student)
            {
                var other_student = (Student)obj; // жёсткое приведение типа - в случае неудачи получаем InvalidCastException
                //var other_student = obj as Student; // мягкое приведение типа - в случае неудачи получаем null
                if (Rating > other_student.Rating)
                    return -1;
                else if (Rating < other_student.Rating)
                    return +1;
                else
                    return 0;
            }
            else
                throw new ArgumentException("Студента можно сравнивать только со студентами!", nameof(obj));

        }

        public bool Equals(Student other)
        {
            return other != null
                && Name == other.Name
                && Surname == other.Surname
                && Math.Abs(Rating - other.Rating) < 0.0001;
        }

        public object Clone()
        {
            //return new Student
            //{
            //    Name = Name,
            //    Surname = Surname,
            //    Rating = Rating
            //};

            var new_student = (Student)MemberwiseClone();

            return new_student;
        }
    }
}
