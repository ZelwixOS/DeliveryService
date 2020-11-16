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


        OrdersMain ordersPage;
        DeliveriesMain deliveriesPage;
        ClientsMain clientsPage;
        CouriersMain couriersPage;
        CarsMain transportsPage;
        CargTypesMain typesOfCargoPage;
        StatusMain statusPage;


        private RelayCommand orderCommand;
        public RelayCommand OrderCommand
        {
            get
            {
                return orderCommand ?? (orderCommand = new RelayCommand(obj =>
                {
                    if (ordersPage == null)
                    {
                        ordersPage = new OrdersMain();
                    }
                    navigation.Navigate(ordersPage);
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

                    if (deliveriesPage == null)
                    {
                        deliveriesPage = new DeliveriesMain();
                    }
                    navigation.Navigate(deliveriesPage);
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
                    if (clientsPage == null)
                    {
                        clientsPage = new ClientsMain();
                    }
                    navigation.Navigate(clientsPage);
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
                    if (couriersPage == null)
                    {
                        couriersPage = new CouriersMain();
                    }
                    navigation.Navigate(couriersPage);
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
                    if (transportsPage == null)
                    {
                        transportsPage = new CarsMain();
                    }
                    navigation.Navigate(transportsPage);
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
                    if (typesOfCargoPage == null)
                    {
                        typesOfCargoPage = new CargTypesMain();
                    }
                    navigation.Navigate(typesOfCargoPage);
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
                    if (statusPage == null)
                    {
                        statusPage = new StatusMain();
                    }
                    navigation.Navigate(statusPage);
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
