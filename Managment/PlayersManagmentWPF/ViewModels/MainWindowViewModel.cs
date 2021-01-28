using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using PlayersManagmentWPF.Models;

namespace PlayersManagmentWPF.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Group> StudentGroups { get; set; }

        private Group _SelectedGroup;
        public Group SelectedGroup
        {
            get => _SelectedGroup;
            set
            {
                _SelectedGroup = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedGroup"));

                SelectedStudent = null;
            }
        }

        private Student _SelectedStudent;

        public Student SelectedStudent
        {
            get => _SelectedStudent;
            set
            {
                _SelectedStudent = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedStudent"));
            }
        }

        public MainWindowViewModel()
        {
            var j = 1;
            var rnd = new Random();
            var groups = Enumerable.Range(1, 10)
               .Select(i => new Group
               {
                   Name = $"Группа - {i}",
                   Students = Enumerable.Range(1, 15)
                      .Select(k => new Student
                      {
                          LastName = $"Фамилия-{j}",
                          FirstName = $"Имя-{j}",
                          Patronymic = $"Отчество-{j++}",
                          Rating = rnd.Next(1, 6)
                      })
                      .ToList()
               })
               .ToList();

            StudentGroups = new(groups);
        }

        public void AddNewGroup()
        {
            var group = new Group
            {
                Name = $"Группа-{StudentGroups.Count + 1}"
            };
            StudentGroups.Add(group);
            SelectedGroup = group;
        }

        public void RemoveSelectedGroup()
        {
            if(SelectedGroup is null) return;
            StudentGroups.Remove(SelectedGroup);
            SelectedGroup = null;
        }
    }
}
