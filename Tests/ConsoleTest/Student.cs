using System.Collections.Generic;

namespace ConsoleTest
{
    class Student
    {
        public string Name { get; init; }

        public string Surname { get; init; }

        public string Patronymic { get; init; }

        public List<int> Ratings { get; set; } = new List<int>();

        public override string ToString() => $"{Surname} {Name} {Patronymic}";
    }
}
