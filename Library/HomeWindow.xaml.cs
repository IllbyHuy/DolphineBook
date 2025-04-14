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
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        private DetailWindow detailWindow; // Thêm biến để lưu trữ cửa sổ chi tiết

        public HomeWindow()
        {
            InitializeComponent();
            LoadBooks(); // Gọi phương thức để tải sách
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private bool IsMaximize = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximize)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1250;
                    this.Height = 830;

                    IsMaximize = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximize = true;
                }
            }
        }

        //private void LogoutButton(object sender, RoutedEventArgs e)
        //{
        //    LoginWindow loginWindow = new LoginWindow();
        //    loginWindow.Show();
        //    this.Close();
        //}

        private void LikeButton(object sender, MouseButtonEventArgs e)
        {
            LikeWindow likeWindow = new LikeWindow();
            likeWindow.Show();
            this.Close();
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LoadBooks()
        {
            var bookrepo = new BookRepo();
            var authorRepo = new AuthorRepo(); 
            var genreRepo = new GenreRepo(); 
            var books = bookrepo.GetAllBooks(); 

            foreach (var book in books)
            {
                Border bookBorder = new Border
                {
                    BorderBrush = System.Windows.Media.Brushes.Gray,
                    BorderThickness = new Thickness(2),
                    CornerRadius = new CornerRadius(5),
                    Margin = new Thickness(10),
                    Width = 200 
                };

                StackPanel bookPanel = new StackPanel
                {
                    Margin = new Thickness(10)
                };

                if (!string.IsNullOrEmpty(book.Image)) 
                {
                    Image bookImage = new Image
                    {
                        Source = new BitmapImage(new Uri(book.Image)), 
                        Width = 100,
                        Height = 150,
                        Margin = new Thickness(5)
                    };
                    bookPanel.Children.Add(bookImage);
                }

                bookPanel.Children.Add(new TextBlock { Text = $"ID: {book.BookId}", Margin = new Thickness(5), FontWeight = FontWeights.Bold });
                bookPanel.Children.Add(new TextBlock { Text = $"Name: {book.BookName}", Margin = new Thickness(5), FontWeight = FontWeights.Bold });

  
                string authorName = authorRepo.GetAuthorNameById(book.AuthorId); 
                bookPanel.Children.Add(new TextBlock { Text = $"Author: {authorName}", Margin = new Thickness(5) });

                bookPanel.Children.Add(new TextBlock { Text = $"Published: {book.Date.Value.ToShortDateString()}", Margin = new Thickness(5) });

                string genreName = genreRepo.GetGenreNameById(book.GenreId); 
                bookPanel.Children.Add(new TextBlock { Text = $"Genre: {genreName}", Margin = new Thickness(5) });

                bookBorder.Child = bookPanel;

                bookBorder.MouseDown += (s, e) =>
                {

                    if (detailWindow == null || !detailWindow.IsVisible)
                    {
                        detailWindow = new DetailWindow();
                        detailWindow.Closed += (s, args) =>
                        {
                            detailWindow = null; 
                            Application.Current.Shutdown(); 
                        };

                        this.Hide(); 
                        detailWindow.LoadBookDetails(book); 
                        detailWindow.Show(); 
                    }
                };

             
                bookBorder.MouseEnter += (s, e) => bookBorder.Background = new SolidColorBrush(Color.FromRgb(173, 216, 230)); 
                bookBorder.MouseLeave += (s, e) => bookBorder.Background = null;

           
                DataWrapPanel.Children.Add(bookBorder);
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

        private void textBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = textBoxSearch.Text.ToLower();
            string selectedFilter = (string)((ComboBoxItem)comboBoxFilter.SelectedItem).Content;

            var bookrepo = new BookRepo();
            var authorRepo = new AuthorRepo(); 
            var genreRepo = new GenreRepo();
            var books = bookrepo.GetAllBooks(); 

            var filteredBooks = books.Where(book =>
                (selectedFilter == "All" && (book.BookName.ToLower().Contains(searchText))) || 
                (selectedFilter == "Genre" && genreRepo.GetGenreNameById(book.GenreId).ToLower().Contains(searchText)) 
            ).ToList();

            DataWrapPanel.Children.Clear();

            foreach (var book in filteredBooks)
            {
               
                Border bookBorder = new Border
                {
                    BorderBrush = System.Windows.Media.Brushes.Gray,
                    BorderThickness = new Thickness(2),
                    CornerRadius = new CornerRadius(5),
                    Margin = new Thickness(10),
                    Width = 200 
                };

                StackPanel bookPanel = new StackPanel
                {
                    Margin = new Thickness(10)
                };

             
                if (!string.IsNullOrEmpty(book.Image)) 
                {
                    Image bookImage = new Image
                    {
                        Source = new BitmapImage(new Uri(book.Image)), 
                        Width = 100,
                        Height = 150,
                        Margin = new Thickness(5)
                    };
                    bookPanel.Children.Add(bookImage);
                }

               
                bookPanel.Children.Add(new TextBlock { Text = $"ID: {book.BookId}", Margin = new Thickness(5), FontWeight = FontWeights.Bold });
                bookPanel.Children.Add(new TextBlock { Text = $"Name: {book.BookName}", Margin = new Thickness(5), FontWeight = FontWeights.Bold });

                
                string authorName = authorRepo.GetAuthorNameById(book.AuthorId); 
                bookPanel.Children.Add(new TextBlock { Text = $"Author: {authorName}", Margin = new Thickness(5) });

              
                bookPanel.Children.Add(new TextBlock { Text = $"Published: {book.Date.Value.ToShortDateString()}", Margin = new Thickness(5) });

           
                string genreName = genreRepo.GetGenreNameById(book.GenreId); 
                bookPanel.Children.Add(new TextBlock { Text = $"Genre: {genreName}", Margin = new Thickness(5) });

                bookBorder.Child = bookPanel;

                
                bookBorder.MouseDown += (s, e) =>
                {
                  
                    if (detailWindow == null || !detailWindow.IsVisible)
                    {
                        detailWindow = new DetailWindow();
                        detailWindow.Closed += (s, args) =>
                        {
                            detailWindow = null; 
                            Application.Current.Shutdown(); 
                        };

                        this.Hide(); 
                        detailWindow.LoadBookDetails(book); 
                        detailWindow.Show(); 
                    }
                };

                bookBorder.MouseEnter += (s, e) => bookBorder.Background = new SolidColorBrush(Color.FromRgb(173, 216, 230));
                bookBorder.MouseLeave += (s, e) => bookBorder.Background = null; 


                DataWrapPanel.Children.Add(bookBorder);
            }
        }

        private void MenuButton_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            LoginWindow logoutWindow = new LoginWindow();
            logoutWindow.Show(); 
        }
    }
}
