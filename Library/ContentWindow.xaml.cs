using Library.DAL.Entities;
using Library.DAL.Repositories;
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
    /// Interaction logic for Content.xaml
    /// </summary>
    public partial class Content : Window
    {
        private Content contentWindow;
        private AuthorRepo authorRepo;
        private GenreRepo genreRepo;
        private Book currentBook;
        public Content(Book book) 
        {
            InitializeComponent();
            authorRepo = new AuthorRepo();
            genreRepo = new GenreRepo();
            currentBook = book; 
            LoadContent();
        }

        public void LoadContent()
        {
            if (currentBook != null) 
            {
                BookNameTextBlock.Text = $"Name: {currentBook.BookName}";
                BookDateTextBlock.Text = $"Date: {currentBook.Date}";
                ContentTextBlock.Text = currentBook.Content.Replace("\n", Environment.NewLine); 
            }
            else
            {
                MessageBox.Show("Không tìm thấy sách.");
            }
        }

        private Book GetBookById(int bookId)
        {
            var bookRepo = new BookRepo(); 
            return bookRepo.GetBookById(bookId); 
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MainBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            
            if (this.WindowState == WindowState.Normal)
            {
               
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
                this.Width = 1250; 
                this.Height = 830; 
            }
        }

        private void HomeButton(object sender, RoutedEventArgs e)
        {
            HomeWindow homeWindow = new HomeWindow();
            homeWindow.Show(); 
            this.Close(); 
        }

        private void LogoutButton(object sender, RoutedEventArgs e)
        {
            this.Close();
            DetailWindow detailWindow = new DetailWindow();
            LoginWindow logoutWindow = new LoginWindow();
            detailWindow.Close();
            logoutWindow.Show();
        }

        private void ReturnToDetailPage_Click(object sender, RoutedEventArgs e)
        {
            DetailWindow detailWindow = new DetailWindow();
            detailWindow.LoadBookDetails(currentBook); 
            detailWindow.Show(); 
            this.Close(); 
        }
    }
}
