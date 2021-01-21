using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    internal static class CollectionsTest
    {
        public static void Run()
        {
            //var array_list = new ArrayList();

            //array_list.Add(3);
            //array_list.Add(5);
            //array_list.Add(7);

            //array_list[1] = "Hello World";

            //int value0 = (int)array_list[0];
            //int value1 = (int)array_list[1];
            //int value2 = (int)array_list[2];

            var students_list = new List<Student>(5);

            students_list.Add(new Student
            {
                Id = 1,
                Surname = "Иванов",
                Name = "Иван",
                Patronymic = "Иванович"
            });

            students_list.Add(new Student
            {
                Id = 2,
                Surname = "Иванов",
                Name = "Иван",
                Patronymic = "Иванович"
            });
            students_list.Add(new Student
            {
                Id = 3,
                Surname = "Иванов",
                Name = "Иван",
                Patronymic = "Иванович"
            });
            students_list.Add(new Student
            {
                Id = 4,
                Surname = "Иванов",
                Name = "Иван",
                Patronymic = "Иванович"
            });
            students_list.Add(new Student
            {
                Id = 5,
                Surname = "Иванов",
                Name = "Иван",
                Patronymic = "Иванович"
            });

            var ivanov = students_list[0];
            students_list.RemoveAt(0);
            var result = students_list.Remove(ivanov);
            students_list.Insert(0, ivanov);

            var linked_list = new LinkedList<Student>();
            //linked_list.First.Next.Next.Next
            var list_node_ivanov = linked_list.AddFirst(new Student
            {
                Id = 1,
                Surname = "Иванов",
                Name = "Иван",
                Patronymic = "Иванович"
            });
            var list_node_petrov = linked_list.AddBefore(
                list_node_ivanov, new Student
                {
                    Id = 0,
                    Surname = "Петров"
                });

            var string_stack = new Stack<string>();
            var string_queue = new Queue<string>();

            var words_frequency = new Dictionary<string, int>();

            var text = "Hello World World Hello Hello hello";

            var words = text.Split(' ');
            foreach (var word in words)
                if (words_frequency.ContainsKey(word))
                    words_frequency[word]++;
                else
                    words_frequency.Add(word, 1);

            //var count = words_frequency["Count"];

            foreach (KeyValuePair<string, int> value in words_frequency)
                Console.WriteLine("Слово {0} встретилось {1} раз", value.Key, value.Value);

            //int hello_world_count;
            //if (words_frequency.ContainsKey("Hello"))
            //    hello_world_count = words_frequency["Hello"];

            //int hello_world_count;
            //if(words_frequency.TryGetValue("Hello", out hello_world_count))
            //    Console.WriteLine("Слово Hello встретилось {0} раз", hello_world_count);

            //if (words_frequency.TryGetValue("Hello", out var hello_world_count))
            //    Console.WriteLine("Слово Hello встретилось {0} раз", hello_world_count);

            var dictionary_words = words_frequency.Keys.ToArray();
            var dictionary_word_counts = words_frequency.Values.ToArray();

            foreach (var word in words_frequency.Keys)
                Console.WriteLine("Слово {0} встретилось {1} раз", word, words_frequency[word]);

            var students_set = new HashSet<Student>();
            students_set.Add(ivanov);

            var ivanov2 = new Student
            {
                Id = 1,
                Surname = "Иванов",
                Name = "Иван",
                Patronymic = "Иванович"
            };

            students_set.Add(ivanov2);

            var ivanov_hash = ivanov.GetHashCode();
            var ivanov2_hash = ivanov2.GetHashCode();

            var uniq_words = new HashSet<string>(/*StringComparer.OrdinalIgnoreCase*/);
            foreach (var word in words)
                uniq_words.Add(word);


            //var decanate = new Decanate();
            const string data_file = "students.txt";
            if (!File.Exists(data_file)) return;

            //decanate.LoadFromFile(data_file);

            var student_list = new List<Student>(Program.GetStudents(data_file));
            var student_stack = new Stack<Student>(Program.GetStudents(data_file));
            var student_queue = new Queue<Student>(Program.GetStudents(data_file));
            var student_set = new HashSet<Student>(Program.GetStudents(data_file));

            var student_link_list = new LinkedList<Student>(Program.GetStudents(data_file));

            //student_list.Contains()
            //student_list.BinarySearch()
            //student_list.RemoveAll(student => student.AverageRating < 3.5);

            //student_list.Capacity = student_list.Count;
            //student_list.Add(new Student());
        }
    }
}
