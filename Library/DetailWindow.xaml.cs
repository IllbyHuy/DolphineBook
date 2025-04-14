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
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        private GenreRepo genreRepo;
        private AuthorRepo authorRepo;
        private Book currentBook;
        public DetailWindow()
        {
            InitializeComponent();
            genreRepo = new GenreRepo();
            authorRepo = new AuthorRepo();
        }

        public void LoadBookDetails(Book book)
        {
            currentBook = book;
            BookIdTextBlock.Text = $"ID: {book.BookId}";
            BookNameTextBlock.Text = $"Name: {book.BookName}";
            BookDateTextBlock.Text = $"Date: {book.Date}"; 
            BookDescriptionTextBlock.Text = $"{book.Description}"; 
            
            string authorName = authorRepo.GetAuthorNameById(book.AuthorId); 
            BookAuthorIdTextBlock.Text = $"Author: {authorName}"; 


            string genreName = genreRepo.GetGenreNameById(book.GenreId); 
            BookGenreIdTextBlock.Text = $"Genre: {genreName}"; 

            if (!string.IsNullOrEmpty(book.Image))
            {
                BookImage.Source = new BitmapImage(new Uri(book.Image));
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        private void ViewContentButton_Click(object sender, RoutedEventArgs e)
        {
  
            Content contentWindow = new Content(currentBook); 
            this.Hide(); 
            contentWindow.Show(); 
        }

        private void HomeButton(object sender, RoutedEventArgs e)
        {
            HomeWindow homeWindow = new HomeWindow();
            homeWindow.Show();
            this.Hide(); 
        }

        private void LogoutButton(object sender, RoutedEventArgs e)
        {
            this.Close(); 
            LoginWindow logoutWindow = new LoginWindow();
            logoutWindow.Show(); 
        }
    }
}
