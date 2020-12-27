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
using DeliveryService.Views.Frames.Delivery;

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


        private RelayCommand refresh;
        public RelayCommand Refresh
        {
            get
            {
                return refresh ?? (refresh = new RelayCommand(obj =>
                {

                    List<DeliveryModel> deliverylist = dbOperations.GetAllDeliveries();
                    List<CourierModel> courierlist = dbOperations.GetAllCouriers();
                    List<TransportModel> carlist = dbOperations.GetAllCars();
                    Deliveries = new ObservableCollection<DeliveryModel>(deliverylist);
                    Courier = new ObservableCollection<CourierModel>(courierlist);
                    Car = new ObservableCollection<TransportModel>(carlist);
                    SelectedDelivery = null;
                }));
            }
        }

        private RelayCommand createDelivery;
        public RelayCommand CreateDelivery
        {
            get
            {
                return createDelivery ?? (createDelivery = new RelayCommand(obj =>
                {
                    SelectedDelivery = new DeliveryModel();
                    selectedDelivery.Date = DateTime.Now;
                    vmCrEd.SelectedDelivery = selectedDelivery;
                    vmCrEd.status = true;

             
                    navigation.Navigate(crEdPage);
                    navigation.ChangeVisibility(Visibility.Hidden);
                }));
            }
        }


        private RelayCommand editDelivery;
        public RelayCommand EditDelivery
        {
            get
            {
                return editDelivery ?? (editDelivery = new RelayCommand(obj =>
                {
                    vmCrEd.SelectedDelivery = selectedDelivery;
                    if (selectedDelivery.ID!=0)
                    vmCrEd.status = false;
                    else
                    vmCrEd.status = true;

                    navigation.Navigate(crEdPage);
                    navigation.ChangeVisibility(Visibility.Hidden);

                },
                    (obj) => (selectedDelivery != null)));
            }
        }

        private RelayCommand deleteDelivery;
        public RelayCommand DeleteDelivery
        {
            get
            {
                return deleteDelivery ?? (deleteDelivery = new RelayCommand(obj =>
                {

                    MessageBoxResult result = System.Windows.MessageBox.Show("Удалить?", "Подтверждение удаления", System.Windows.MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        List<OrderModel> orderModels = dbOperations.GetAllOrders().Where(i => i.Delivery_ID_FK == selectedDelivery.ID).ToList();

                        foreach (OrderModel o in orderModels)
                        {
                            o.Delivery_ID_FK = null;
                            o.Status_ID_FK = 2;
                            dbOperations.UpdateOrder(o);
                        }

                        dbOperations.DeleteDelivery(selectedDelivery.ID);

                        List<DeliveryModel> deliverylist = dbOperations.GetAllDeliveries();
                        Deliveries = new ObservableCollection<DeliveryModel>(deliverylist);
                        SelectedDelivery = null;

                    }

                },
                    (obj) => (selectedDelivery != null)
                ));
            }
        }


        private RelayCommand searchDelivery;
        public RelayCommand SearchDelivery
        {
            get
            {
                return searchDelivery ?? (searchDelivery = new RelayCommand(obj =>
                {
                    List<string> keyWords = new List<string>();
                    string req = search;
                    if (req != null)
                    {
                        keyWords.AddRange(req.Split(' '));
                        ObservableCollection<DeliveryModel> del = new ObservableCollection<DeliveryModel>();
                        List<DeliveryModel> deliverylist = dbOperations.GetAllDeliveries();
                        Deliveries = new ObservableCollection<DeliveryModel>(deliverylist);
                        foreach (DeliveryModel d in deliveries)
                        {
                            string order = ConstrStringDelivery(d);
                            bool st = true;
                            for (int i = 0; i < keyWords.Count; i++)
                                if (!order.Contains(keyWords[i]))
                                {
                                    st = false;
                                    break;
                                }
                            if (st)
                                del.Add(d);
                        }
                        Deliveries = del;
                    }

                }));
            }
        }


        string ConstrStringDelivery(DeliveryModel o)
        {
            string res;
            res = o.DateS + o.Distance + o.KmPrice;

            string cour = dbOperations.GetCourier(o.Courier_ID_FK).CourierName;
            res = res + cour;

            var transp = car.Where(i => i.ID == o.Transport_ID_FK).ToList();
            if (transp.Count != 0)
            {
                res = res + transp.First().TransportName + transp.First().Number;
            }
            return res;
        }



        CreateEditDelivery crEdPage;
        VMDeliveryCreateEdit vmCrEd;

        public VMDeliveries()
        {
            navigation = IoC.Get<INavigation>();
            navigation.CurrentPageChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            navigation.VisibilityChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            dbOperations = BLL.ServiceModules.IoC.Get<IdbCrud>();

            List<DeliveryModel> deliverylist = dbOperations.GetAllDeliveries();
            List<CourierModel> courierlist = dbOperations.GetAllCouriers();
            List<TransportModel> carlist = dbOperations.GetAllCars();
            Deliveries = new ObservableCollection<DeliveryModel>(deliverylist);
            Courier = new ObservableCollection<CourierModel>(courierlist);
            Car = new ObservableCollection<TransportModel>(carlist);

            vmCrEd = new VMDeliveryCreateEdit();
            crEdPage = new CreateEditDelivery(vmCrEd);

        }
    }
}
