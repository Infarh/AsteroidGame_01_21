using System.Collections.Generic;

namespace ConsoleTest
{
    class Student
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public string Surname { get; init; }

        public string Patronymic { get; init; }

        public List<int> Ratings { get; set; } = new List<int>();

        public double AverageRating
        {
            get
            {
                if (Ratings is null || Ratings.Count == 0)
                    return double.NaN;

                var result = 0;

                foreach (var rating in Ratings)
                    result += rating;

                return (double)result / Ratings.Count;
            }
        }

        public override string ToString() => $"{Surname} {Name} {Patronymic} rating:{AverageRating:0.0##}";
    }
}
