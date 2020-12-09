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
    class VMCars : VMBase
    {
        private readonly INavigation navigation;
        private readonly IdbCrud dbOperations;

        private CustomerModel selectedCars;
        public CustomerModel SelectedCars
        {
            get { return selectedCars; }
            set
            {
                selectedCars = value;
                OnPropertyChanged("SelectedCars");
            }
        }
        public Page CurrentPage => navigation.CurrentPage;
        public Visibility CurrentVisibility => navigation.CurrentVisibility;

        private ObservableCollection<TransportModel> cars;
        public ObservableCollection<TransportModel> Cars
        {
            get { return cars; }
            set
            {
                cars = value;
                OnPropertyChanged();
            }
        }



        public VMCars()
        {
            navigation = IoC.Get<INavigation>();
            navigation.CurrentPageChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            navigation.VisibilityChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            dbOperations = BLL.ServiceModules.IoC.Get<IdbCrud>();

            List<TransportModel> carlist = dbOperations.GetAllCars();

            cars = new ObservableCollection<TransportModel>(carlist);

        }
    }
}
