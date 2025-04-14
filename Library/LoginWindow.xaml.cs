using Library.BLL.Services;
using Library.DAL.Entities;
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
using System.Windows.Shapes;

namespace Library
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        private MemberService _service = new();

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void MainBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void userNameTB_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void passwordTB_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string useremail = userNameTB.TextValue;
            string password = passwordTB.TextValue;

            Console.WriteLine($"Email: {useremail}, Password: {password}");

            User account = _service.Authenticate(useremail, password);
            if (account == null)
            {
                MessageBox.Show("Invalid email address or wrong password", "Wrong credentials", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (account.Role == 3)
            {
                ManagementWindow managementWindow = new ManagementWindow();
                managementWindow.Show();
            }
            else
            {
   
                HomeWindow homeWindow = new HomeWindow();
                homeWindow.Show();
            }

            this.Close(); 
        }
    }
}
