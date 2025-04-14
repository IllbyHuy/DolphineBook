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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Library.CustomControl
{
    /// <summary>
    /// Interaction logic for WaterMarkTestBox.xaml
    /// </summary>
    public partial class WaterMarkTestBox : UserControl
    {
        public WaterMarkTestBox()
        {
            InitializeComponent();
        }

        public string TextValue
        {
            get { return (string)GetValue(TextValueProperty); }
            set { SetValue(TextValueProperty, value); }
        }

        public static readonly DependencyProperty TextValueProperty =
            DependencyProperty.Register("TextValue", typeof(string), typeof(WaterMarkTestBox), new PropertyMetadata(string.Empty));

        public bool IsPassword
        {
            get { return (bool)GetValue(IsPasswordProperty); }
            set { SetValue(IsPasswordProperty, value); }
        }

        public static readonly DependencyProperty IsPasswordProperty =
            DependencyProperty.Register("IsPassword", typeof(bool), typeof(WaterMarkTestBox), new PropertyMetadata(false, OnIsPasswordChanged));

        public string LabelMark
        {
            get { return (string)GetValue(LabelMarkProperty); }
            set { SetValue(LabelMarkProperty, value); }
        }

        public static readonly DependencyProperty LabelMarkProperty =
            DependencyProperty.Register("LabelMark", typeof(string), typeof(WaterMarkTestBox), new PropertyMetadata(string.Empty));

        private void Control_GotFocus(object sender, RoutedEventArgs e)
        {
            if (this.IsPassword)
            {
                togglePassword.Visibility = Visibility.Visible;
            }

            var animation = new ThicknessAnimation(new Thickness(5, -27, 5, 0), TimeSpan.FromSeconds(0.2));
            watermarkTB.BeginAnimation(Label.MarginProperty, animation);
            watermarkTB.BeginAnimation(Label.FontSizeProperty, new DoubleAnimation(12, TimeSpan.FromSeconds(0.2)));
            watermarkTB.Foreground = Brushes.Gray;
            watermarkTB.FontWeight = FontWeights.Bold;
            border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#333333"));
            border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F9F9F9"));
        }

        private void Control_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.IsPassword)
            {
                togglePassword.Visibility = Visibility.Collapsed;
            }

            if (string.IsNullOrEmpty(textBox.Text) && string.IsNullOrEmpty(passwordBox.Password))
            {
                var animation = new ThicknessAnimation(new Thickness(15, 0, 0, 0), TimeSpan.FromSeconds(0.2));
                watermarkTB.BeginAnimation(Label.MarginProperty, animation);
                watermarkTB.BeginAnimation(Label.FontSizeProperty, new DoubleAnimation(14, TimeSpan.FromSeconds(0.2)));
                watermarkTB.Foreground = Brushes.Gray;
                watermarkTB.FontWeight = FontWeights.Normal;
            }

            border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#EDEDED"));
            border.BorderBrush = Brushes.Transparent;
        }

        private void HidePassword_Checked(object sender, RoutedEventArgs e)
        {
            if (!this.IsPassword) return;
            passwordBox.Visibility = Visibility.Visible;
            textBox.Visibility = Visibility.Collapsed;

            passwordBox.Password = textBox.Text;
            textBox.Text = null;
        }

        private void ShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            passwordBox.Visibility = Visibility.Collapsed;
            textBox.Visibility = Visibility.Visible;

            textBox.Text = passwordBox.Password;
            passwordBox.Password = null;
        }

        private static void OnIsPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            WaterMarkTestBox thisControl = d as WaterMarkTestBox;
            if (thisControl == null) return;

            if (thisControl.IsPassword)
            {
                thisControl.passwordBox.Visibility = Visibility.Visible;
                thisControl.textBox.Visibility = Visibility.Collapsed;
            }
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox pb && pb.Password != null)
            {
                TextValue = pb.Password;
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox tb && tb.Text != null)
            {
                TextValue = tb.Text;
            }
        }
    }
}
