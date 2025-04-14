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
    /// Interaction logic for ManagementWindow.xaml
    /// </summary>
    public partial class ManagementWindow : Window
    {
        private BookService _serv = new();
        private AuthorService _author = new();

        public ManagementWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGrid(_serv.GetAllBook_2());      
        }
        private void FillDataGrid(List<Book> arr)
        {
            BookGrid.ItemsSource = null;
            BookGrid.ItemsSource = arr;

        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Book? selected = BookGrid.SelectedItem as Book;

            if (selected == null)
            {
                MessageBox.Show("Please select a book before deleting!", "Select on", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            MessageBoxResult answer = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (answer == MessageBoxResult.No)
            {
                return;
            }

            _serv.DeleteBook(selected);
            FillDataGrid(_serv.GetAllBook_2());

        }



        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            DetailManagementWindow detailWindow = new DetailManagementWindow();
            detailWindow.ShowDialog();

            FillDataGrid(_serv.GetAllBook_2());

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

            Book? selected = BookGrid.SelectedItem as Book;

            if (selected == null)
            {
                MessageBox.Show("Please select a book before updating!", "Select on", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }


            DetailManagementWindow detailWindow = new DetailManagementWindow();

            detailWindow.EditedOne = selected;

            detailWindow.ShowDialog();
            FillDataGrid(_serv.GetAllBook_2());
        }

        private void CreateAuthorButton(object sender, RoutedEventArgs e)
        {
            DetailAuthorWindow detailWindow = new();
            detailWindow.ShowDialog();
        }
    }
}
