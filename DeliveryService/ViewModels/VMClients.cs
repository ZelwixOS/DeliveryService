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

        private string search;
        public string Search
        {
            get { return search; }
            set
            {
                search = value;
                OnPropertyChanged("Search");
            }
        }

        bool status;

        private string textCreate;
        public string TextCreate
        {
            get { return textCreate; }
            set
            {
                textCreate = value;
                OnPropertyChanged("TextCreate");
            }
        }

        private string kindCreate;
        public string KindCreate
        {
            get { return kindCreate; }
            set
            {
                kindCreate = value;
                OnPropertyChanged("KindCreate");
            }
        }

        private CustomerModel selectedClient;
        public CustomerModel SelectedClient
        {
            get { return selectedClient; }
            set
            {
                if (status)
                {
                    Clients.Remove(selectedClient);
                    CreateStatusChanged();
                }
                selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }

        void CreateStatusChanged()
        {
            if (status)
            {
                status = false;
                TextCreate = "Новый";
                KindCreate = "Add";
            }
            else
            {
                status = true;
                TextCreate = "Сохранить";
                KindCreate = "ContentSaveAll";
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

        private RelayCommand editClient;
        public RelayCommand EditClient
        {
            get
            {
                return editClient ?? (editClient = new RelayCommand(obj =>
                {
                    dbOperations.UpdateCustomer(SelectedClient);
                },
                    (obj) => (selectedClient != null && (!status))));
            }
        }

        private RelayCommand createClient;
        public RelayCommand CreateClient
        {
            get
            {
                return createClient ?? (createClient = new RelayCommand(obj =>
                {
                    if (!status)
                    {
                        SelectedClient = new CustomerModel();
                        Clients.Add(selectedClient);
                    }
                    else
                    {
                        selectedClient.Discount = 0;
                        dbOperations.CreateCustomer(selectedClient);
                        Clients = new ObservableCollection<CustomerModel>(dbOperations.GetAllCustomers());
                        SelectedClient = null;
                    }
                    CreateStatusChanged();
                }));
            }
        }

        private RelayCommand deleteClient;
        public RelayCommand DeleteClient
        {
            get
            {
                return deleteClient ?? (deleteClient = new RelayCommand(obj =>
                {
                    MessageBoxResult result = System.Windows.MessageBox.Show("Удалить?", "Подтверждение удаления", System.Windows.MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        dbOperations.DeleteCustomer(selectedClient.ID);
                        Clients = new ObservableCollection<CustomerModel>(dbOperations.GetAllCustomers());
                        SelectedClient = null;
                    }
                },
                    (obj) => (selectedClient != null&&(!status))));
            }
        }


        private RelayCommand refresh;
        public RelayCommand Refresh
        {
            get
            {
                return refresh ?? (refresh = new RelayCommand(obj =>
                {
                    Clients = new ObservableCollection<CustomerModel>(dbOperations.GetAllCustomers());
                    SelectedClient = null;
                }));
            }
        }


        private RelayCommand searchClient;
        public RelayCommand SearchClient
        {
            get
            {
                return searchClient ?? (searchClient = new RelayCommand(obj =>
                {
                    List<string> keyWords = new List<string>();
                    string req = search;
                    if (req != null)
                    {
                        keyWords.AddRange(req.Split(' '));
                        ObservableCollection<CustomerModel> cl = new ObservableCollection<CustomerModel>();
                        List<CustomerModel> clientlist = dbOperations.GetAllCustomers();
                        Clients = new ObservableCollection<CustomerModel>(clientlist);
                        foreach (CustomerModel c in clients)
                        {
                            string client = c.CustomerName+c.Discount;
                            bool st = true;
                            for (int i = 0; i < keyWords.Count; i++)
                                if (!client.Contains(keyWords[i]))
                                {
                                    st = false;
                                    break;
                                }
                            if (st)
                                cl.Add(c);
                        }
                        Clients = cl;
                    }

                }));
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

            TextCreate = "Новый";
            KindCreate = "Add";
            status = false;
        }
    }
}
