using System;

namespace PlayersManagmentWPF.Models
{
    public class Student
    {
        private string _LastName;
        public string LastName
        {
            get => _LastName;
            set
            {
                _LastName = value;
                LastNameChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler LastNameChanged;

        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        public double Rating { get; set; }
    }
}
