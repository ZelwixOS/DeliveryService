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
    class VMClients : VMBase
    {
        private readonly INavigation navigation;
        private readonly IdbCrud dbOperations;

        private CustomerModel selectedClient;
        public CustomerModel SelectedClient
        {
            get { return selectedClient; }
            set
            {
                selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }
        public Page CurrentPage => navigation.CurrentPage;
        public Visibility CurrentVisibility => navigation.CurrentVisibility;

        private ObservableCollection<CustomerModel> clients;
        public ObservableCollection<CustomerModel> Clients
        {
            get { return clients; }
            set
            {
                clients = value;
                OnPropertyChanged();
            }
        }




        public VMClients()
        {
            navigation = IoC.Get<INavigation>();
            navigation.CurrentPageChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            navigation.VisibilityChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            dbOperations = BLL.ServiceModules.IoC.Get<IdbCrud>();

            List<CustomerModel> clientlist = dbOperations.GetAllCustomers();
   
            clients = new ObservableCollection<CustomerModel>(clientlist);

        }
    }
}
