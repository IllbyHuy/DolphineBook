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
    /// Interaction logic for DetailAuthorWindow.xaml
    /// </summary>
    public partial class DetailAuthorWindow : Window
    {
        public DetailAuthorWindow()
        {
            InitializeComponent();
        }
        public Author author {  get; set; }
        public AuthorService _auServ = new();

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {


            Author obj = new();

            
            obj.AuthorId = int.Parse(AuthorIdTextBox.Text);
            obj.AuthorName = AuthorNameTextBox.Text;

            _auServ.CreateAu(obj);

           
            this.Close();


        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

      
    }
}
