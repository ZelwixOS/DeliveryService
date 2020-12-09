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
    class VMCouriers : VMBase
    {
        private readonly INavigation navigation;
        private readonly IdbCrud dbOperations;

        private CourierModel selectedCourier;
        public CourierModel SelectedCourier
        {
            get { return selectedCourier; }
            set
            {
                selectedCourier = value;
                OnPropertyChanged("SelectedCourier");
            }
        }
        public Page CurrentPage => navigation.CurrentPage;
        public Visibility CurrentVisibility => navigation.CurrentVisibility;

        private ObservableCollection<CourierModel> couriers;
        public ObservableCollection<CourierModel> Couriers
        {
            get { return couriers; }
            set
            {
                couriers = value;
                OnPropertyChanged();
            }
        }




        public VMCouriers()
        {
            navigation = IoC.Get<INavigation>();
            navigation.CurrentPageChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            navigation.VisibilityChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            dbOperations = BLL.ServiceModules.IoC.Get<IdbCrud>();

            List<CourierModel> courierlist = dbOperations.GetAllCouriers();

            couriers = new ObservableCollection<CourierModel>(courierlist);

        }
    }
}
