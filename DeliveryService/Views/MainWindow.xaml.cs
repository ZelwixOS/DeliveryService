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
using DeliveryService.Frames.Main;
using DeliveryService.Frames;
using MaterialDesignThemes.Wpf;

namespace DeliveryService
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       

        public MainWindow()
        {
            InitializeComponent();
         
        }

        private void FullSizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
            FullSizeButton.Visibility = Visibility.Collapsed;
            NormalSizeButton.Visibility = Visibility.Visible;
        }

        private void NormalSizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Normal;
            FullSizeButton.Visibility = Visibility.Visible;
            NormalSizeButton.Visibility = Visibility.Collapsed;
        }

        private void UpperBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
            if (WindowState == WindowState.Maximized)
            {
                FullSizeButton.Visibility = Visibility.Collapsed;
                NormalSizeButton.Visibility = Visibility.Visible;
            }
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
