using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
    class Player
    {
        //private string _Name;
        //private string _Surname;
        //private DateTime _Birthday;

        //public string Name
        //{
        //    get => _Name;
        //    set => _Name = value;
        //}

        //public string Surname
        //{
        //    get => _Surname;
        //    set => _Surname = value;
        //}

        //public DateTime Birthday
        //{
        //    get => _Birthday;
        //    set => _Birthday = value;
        //}

        public string Name { get; /*private*/ set; }
        public string Surname { /*internal*/ get; set; }
        public DateTime? Birthday { get; set; } = null;

        public Player()
        {
            
        }

        public Player(string Name)
        {
            this.Name = Name;
        }

        public Player(string Name, string Surname)
            : this(Name)
        {
            //this.Name = Name;
            this.Surname = Surname;
        }
    }
}
