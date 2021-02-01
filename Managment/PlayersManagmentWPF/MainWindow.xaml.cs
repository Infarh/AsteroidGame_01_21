using System.Windows;

using PlayersManagmentWPF.Models;
using PlayersManagmentWPF.ViewModels;

namespace PlayersManagmentWPF
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            //DataContext = new MainWindowViewModel();
        }

        private void OnAddGroupButtonClick(object Sender, RoutedEventArgs E)
        {
            var model = (MainWindowViewModel)DataContext;

            //model.StudentGroups.Add(new Group
            //{
            //    Name = $"Группа-{model.StudentGroups.Count + 1}"
            //});
            model.AddNewGroup();
        }

        private void OnRemoveGroupButtonClick(object Sender, RoutedEventArgs E)
        {
            var model = (MainWindowViewModel)DataContext;

            //var selected_group = (Group)StudentGroups.SelectedItem;
            //if(selected_group is null) return;

            //model.StudentGroups.Remove(selected_group);
            model.RemoveSelectedGroup();
        }
    }
}
