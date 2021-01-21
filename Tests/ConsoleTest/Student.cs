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

        public override int GetHashCode()
        {
            var hash = Id.GetHashCode();

            unchecked
            {
                if (Surname != null) hash = (hash * 257) ^ Surname.GetHashCode();
                if (Name != null) hash = (hash * 257) ^ Name.GetHashCode();
                if (Patronymic != null) hash = (hash * 257) ^ Patronymic.GetHashCode();
            }

            return hash;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj.GetType() != typeof(Student)) return false;

            var other = (Student) obj;
            return Id == other.Id
                && Surname == other.Surname
                && Name == other.Name
                && Patronymic == other.Patronymic;
        }
    }
}
