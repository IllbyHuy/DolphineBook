using Library.BLL.Services;
using Library.DAL.Entities;
using Microsoft.VisualBasic.ApplicationServices;
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
    /// Interaction logic for DetailManagementWindow.xaml
    /// </summary>
    public partial class DetailManagementWindow : Window

    {
        public Book EditedOne { get; set; }

        public AuthorService _auServ = new();
        public BookService _serv = new();
        public GenreService _genServ = new();
        
        public DetailManagementWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillCombobox();

            BookIdTextBox.IsEnabled = true;
            if (EditedOne != null)
            {
                FillElement();
            }


        }
        private void FillElement()
        {
            BookIdTextBox.Text = EditedOne.BookId.ToString();
            BookNameTextBox.Text = EditedOne.BookName;
            AuthorComboBox.SelectedValue = EditedOne.AuthorId;
            GenreComboBox.SelectedValue = EditedOne.GenreId;
            DecriptionTextBox.Text = EditedOne.Description;
            ContentTextBox.Text = EditedOne.Content;
            PublicationDateDatePicker.SelectedDate = EditedOne.Date.GetValueOrDefault();
            ImageTextBox.Text = EditedOne.Image;


        }

        private void FillCombobox()
        {

            GenreComboBox.ItemsSource = _genServ.GetAllGen();
            AuthorComboBox.ItemsSource = _auServ.GetAllAuth();

            GenreComboBox.DisplayMemberPath = "GenreName";
            GenreComboBox.SelectedValuePath = "GenreId";

            AuthorComboBox.DisplayMemberPath = "AuthorName";
            AuthorComboBox.SelectedValuePath = "AuthorId";
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {


            Book obj = new();

            obj.BookId = int.Parse(BookIdTextBox.Text);
            obj.BookName = BookNameTextBox.Text;
            obj.AuthorId = (int)AuthorComboBox.SelectedValue;
            obj.Content = ContentTextBox.Text;
            obj.Image = ImageTextBox.Text;
            obj.Description = DecriptionTextBox.Text;
            obj.Date = PublicationDateDatePicker.SelectedDate;
            obj.GenreId = (int)GenreComboBox.SelectedValue;

            if (EditedOne == null)
            {
                _serv.CreateBook(obj);
                
            }
            else
            {
                _serv.UpdateBook(obj);
            }
            this.Close();


        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
