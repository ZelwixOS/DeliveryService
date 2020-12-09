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
    class VMTypesOfCargo : VMBase
    {
        private readonly INavigation navigation;
        private readonly IdbCrud dbOperations;

        private CustomerModel selectedCargoType;
        public CustomerModel SelectedCargoType
        {
            get { return selectedCargoType; }
            set
            {
                selectedCargoType = value;
                OnPropertyChanged("SelectedCargoType");
            }
        }
        public Page CurrentPage => navigation.CurrentPage;
        public Visibility CurrentVisibility => navigation.CurrentVisibility;

        private ObservableCollection<TypeOfCargoModel> cargoTypes;
        public ObservableCollection<TypeOfCargoModel> CargoTypes
        {
            get { return cargoTypes; }
            set
            {
                cargoTypes = value;
                OnPropertyChanged();
            }
        }



        public VMTypesOfCargo()
        {
            navigation = IoC.Get<INavigation>();
            navigation.CurrentPageChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            navigation.VisibilityChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            dbOperations = BLL.ServiceModules.IoC.Get<IdbCrud>();

            List<TypeOfCargoModel> cargoTypeslist = dbOperations.GetAllTypesOfCargo();

            cargoTypes = new ObservableCollection<TypeOfCargoModel>(cargoTypeslist);

        }
    }
}
