using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;
using BLL.Interfaces;
using DeliveryService.Navigation;
using System.Windows.Controls;
using System.Windows;
using System.Collections.ObjectModel;

namespace DeliveryService.ViewModels
{
    class VMDeliveries : VMBase
    {
        private readonly INavigation navigation;
        private readonly IdbCrud dbOperations;

        private DeliveryModel selectedDelivery;
        public DeliveryModel SelectedDelivery
        {
            get { return selectedDelivery; }
            set
            {
                selectedDelivery = value;
                OnPropertyChanged("SelectedDelivery");
            }
        }
        public Page CurrentPage => navigation.CurrentPage;
        public Visibility CurrentVisibility => navigation.CurrentVisibility;

        private ObservableCollection<DeliveryModel> deliveries;
        public ObservableCollection<DeliveryModel> Deliveries
        {
            get { return deliveries; }
            set
            {
                deliveries = value;
                OnPropertyChanged();
            }
        }

      
        private ObservableCollection<CourierModel> courier;
        public ObservableCollection<CourierModel> Courier
        {
            get { return courier; }
            set
            {
                courier = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<TransportModel> car;
        public ObservableCollection<TransportModel> Car
        {
            get { return car; }
            set
            {
                car = value;
                OnPropertyChanged();
            }
        }


        public VMDeliveries()
        {
            navigation = IoC.Get<INavigation>();
            navigation.CurrentPageChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            navigation.VisibilityChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            dbOperations = BLL.ServiceModules.IoC.Get<IdbCrud>();

            List<DeliveryModel> deliverylist = dbOperations.GetAllDeliveries();
            List<CourierModel> courierlist = dbOperations.GetAllCouriers();
            List<TransportModel> carlist = dbOperations.GetAllCars();
            deliveries = new ObservableCollection<DeliveryModel>(deliverylist);
            courier = new ObservableCollection<CourierModel>(courierlist);
            car = new ObservableCollection<TransportModel>(carlist);
        }
    }
}
