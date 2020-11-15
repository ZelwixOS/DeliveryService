using BLL.Models;
using DeliveryService.Navigation;
using System.Windows.Controls;
using System.Windows;
using DeliveryService.Frames.Main;

namespace DeliveryService.ViewModels
{
    class VMMainWindow : VMBase
    {
        private readonly INavigation navigation;

        public Page CurrentPage => navigation.CurrentPage;
        public Visibility CurrentVisibility => navigation.CurrentVisibility;


        private RelayCommand orderCommand;
        public RelayCommand OrderCommand
        {
            get
            {
                return orderCommand ?? (orderCommand = new RelayCommand(obj =>
                {
                    navigation.Navigate(new OrdersMain());
                    navigation.ChangeVisibility(Visibility.Hidden);
                }));
            }
        }

        private RelayCommand deliveryCommand;
        public RelayCommand DeliveryCommand
        {
            get
            {
                return deliveryCommand ?? (deliveryCommand = new RelayCommand(obj =>
                {
                        navigation.Navigate(new DeliveriesMain());
                        navigation.ChangeVisibility(Visibility.Hidden);
                }));
            }
        }


        private RelayCommand clientCommand;
        public RelayCommand ClientCommand
        {
            get
            {
                return clientCommand ?? (clientCommand = new RelayCommand(obj =>
                {
                    navigation.Navigate(new ClientsMain());
                    navigation.ChangeVisibility(Visibility.Hidden);
                }));
            }
        }

        private RelayCommand courierCommand;
        public RelayCommand CourierCommand
        {
            get
            {
                return courierCommand ?? (courierCommand = new RelayCommand(obj =>
                {
                    navigation.Navigate(new CouriersMain());
                    navigation.ChangeVisibility(Visibility.Hidden);
                }));
            }
        }

        private RelayCommand transportCommand;
        public RelayCommand TransportCommand
        {
            get
            {
                return transportCommand ?? (transportCommand = new RelayCommand(obj =>
                {
                    navigation.Navigate(new CarsMain());
                    navigation.ChangeVisibility(Visibility.Hidden);
                }));
            }
        }

        private RelayCommand typeOfCargoCommand;
        public RelayCommand TypeOfCargoCommand
        {
            get
            {
                return typeOfCargoCommand ?? (typeOfCargoCommand = new RelayCommand(obj =>
                {
                    navigation.Navigate(new CargTypesMain());
                    navigation.ChangeVisibility(Visibility.Hidden);
                }));
            }
        }

        private RelayCommand statusCommand;
        public RelayCommand StatusCommand
        {
            get
            {
                return statusCommand ?? (statusCommand = new RelayCommand(obj =>
                {
                    navigation.Navigate(new StatusMain());
                    navigation.ChangeVisibility(Visibility.Hidden);
                }));
            }
        }

        public VMMainWindow()
        {
            navigation = IoC.Get<INavigation>();
            navigation.CurrentPageChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            navigation.VisibilityChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            navigation.Navigate(new OrdersMain());
            navigation.ChangeVisibility(Visibility.Hidden);
        }

    }
}
