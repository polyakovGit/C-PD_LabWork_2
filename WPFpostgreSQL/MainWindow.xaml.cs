using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFpostgreSQL.Data;

namespace WPFpostgreSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext context;
        User NewUser = new User();
        User selectedUser = new User();


        public MainWindow(ApplicationContext context)
        {
            this.context = context;
            InitializeComponent();
            GetUsers();
            NewUserGrid.DataContext = NewUser;
        }


        private void GetUsers()
        {
            //UserDG.ItemsSource = context.Users.ToList();
            UserDG.ItemsSource = context.Users.Include(c => c.Profile).ToList(); 
        }

        private void AddItem(object s, RoutedEventArgs e)
        {
            context.Users.Add(NewUser);
            context.SaveChanges();
            GetUsers();
            NewUser = new User();
            NewUserGrid.DataContext = NewUser;
        }

        private void UpdateItem(object s, RoutedEventArgs e)
        {
            context.Update(selectedUser);
            context.SaveChanges();
            GetUsers();
        }

        private void SelectUserToEdit(object s, RoutedEventArgs e)
        {
            selectedUser = (s as FrameworkElement).DataContext as User;
            UpdateUserGrid.DataContext = selectedUser;
        }

        private void DeleteUser(object s, RoutedEventArgs e)
        {
            var userToDelete = (s as FrameworkElement).DataContext as User;
            context.Users.Remove(userToDelete);
            context.SaveChanges();
            GetUsers();
        }
    }
}
