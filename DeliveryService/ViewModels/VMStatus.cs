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
    class VMStatus : VMBase
    {
        private readonly INavigation navigation;
        private readonly IdbCrud dbOperations;

        private CustomerModel selectedStatus;
        public CustomerModel SelectedStatus
        {
            get { return selectedStatus; }
            set
            {
                selectedStatus = value;
                OnPropertyChanged("SelectedStatus");
            }
        }
        public Page CurrentPage => navigation.CurrentPage;
        public Visibility CurrentVisibility => navigation.CurrentVisibility;

        private ObservableCollection<StatusModel> status;
        public ObservableCollection<StatusModel> Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged();
            }
        }



        public VMStatus()
        {
            navigation = IoC.Get<INavigation>();
            navigation.CurrentPageChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            navigation.VisibilityChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            dbOperations = BLL.ServiceModules.IoC.Get<IdbCrud>();

            List<StatusModel> statuslist = dbOperations.GetAllStatuses();
   
            status = new ObservableCollection<StatusModel>(statuslist);

        }
    }
}
