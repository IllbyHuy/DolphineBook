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
    /// Interaction logic for LikeWindow_.xaml
    /// </summary>
    public partial class LikeWindow : Window
    {
        public LikeWindow()
        {
            InitializeComponent();
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


        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void MenuButton_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void HomeButton(object sender, MouseButtonEventArgs e)
        {
            HomeWindow homeWindow = new HomeWindow();
            homeWindow.Show();
            this.Close();

        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra trạng thái hiện tại của cửa sổ
            if (this.WindowState == WindowState.Normal)
            {
                // Nếu cửa sổ đang ở chế độ bình thường, phóng to nó
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                // Nếu cửa sổ đang ở chế độ phóng to, đưa nó về chế độ bình thường
                this.WindowState = WindowState.Normal;
                this.Width = 1250; // Đặt lại chiều rộng
                this.Height = 830;  // Đặt lại chiều cao
            }
        }
        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void MainBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        
    }
}
