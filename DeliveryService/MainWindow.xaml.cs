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


namespace DeliveryService
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OrdersMain OrderMainPage;
        DeliveriesMain DeliveryMainPage;
        ClientsMain ClientMainPage;
        CouriersMain CourierMainPage;
        CarsMain CarMainPage;
        CargTypesMain CargoTypeMainPage;
        StatusMain StatusMainPage;

        public MainWindow()
        {
            InitializeComponent();

            OrderMainPage = new OrdersMain();
            DeliveryMainPage = new DeliveriesMain();
            ClientMainPage = new ClientsMain();
            CourierMainPage = new CouriersMain();
            CarMainPage = new CarsMain();
            CargoTypeMainPage = new CargTypesMain();
            StatusMainPage = new StatusMain();

            WorkFrame.Navigate(OrderMainPage);

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
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

        private void DeliveryMenuButton_Click(object sender, RoutedEventArgs e)
        {
            WorkFrame.Navigate(DeliveryMainPage);

        }

        private void OrderMenuButton_Click(object sender, RoutedEventArgs e)
        {
            WorkFrame.Navigate(OrderMainPage);
        }

        private void ClientMenuButton_Click(object sender, RoutedEventArgs e)
        {
            WorkFrame.Navigate(ClientMainPage);
        }

        private void CourierMenuButton_Click(object sender, RoutedEventArgs e)
        {

            WorkFrame.Navigate(CourierMainPage);
        }

        private void CarMenuButton_Click(object sender, RoutedEventArgs e)
        {
            WorkFrame.Navigate(CarMainPage);

        }

        private void CargoTypeMenuButton_Click(object sender, RoutedEventArgs e)
        {
            WorkFrame.Navigate(CargoTypeMainPage);

        }

        private void StatusMenuButton_Click(object sender, RoutedEventArgs e)
        {
            WorkFrame.Navigate(StatusMainPage);

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


        private void CollapseButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
