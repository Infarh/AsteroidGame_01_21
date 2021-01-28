using System.Collections.Generic;

namespace PlayersManagmentWPF.Models
{
    public class Group
    {
        public string Name { get; set; }

        public List<Student> Students { get; set; } = new();

        //public override string ToString() => Name;
    }
}
