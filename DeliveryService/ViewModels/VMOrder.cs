using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService.Navigation;
using System.Windows.Controls;
using System.Windows;
using BLL.Models;
using BLL.Interfaces;
using BLL.ServiceModules;
using Ninject;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using DeliveryService.Views.Frames.Order;
using DeliveryService.Frames.Main;

namespace DeliveryService.ViewModels
{
    public class VMOrder : VMBase
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




        private OrderModel selectedOrder;
        public OrderModel SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            }
        }
        public Page CurrentPage => navigation.CurrentPage;
        public Visibility CurrentVisibility => navigation.CurrentVisibility;

        private ObservableCollection<OrderModel> orders;
        public ObservableCollection<OrderModel> Orders
        {
            get { return orders; }
            set 
            { 
                orders = value;
                OnPropertyChanged("Orders");
            }
        }

        private ObservableCollection<StatusModel> status;
        public ObservableCollection<StatusModel> Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }

        private ObservableCollection<CustomerModel> customer;
        public ObservableCollection<CustomerModel> Customer
        {
            get { return customer; }
            set
            {
                customer = value;
                OnPropertyChanged("Customer");
            }
        }

        private ObservableCollection<TypeOfCargoModel> typeOfCargo;
        public ObservableCollection<TypeOfCargoModel> TypeOfCargo
        {
            get { return typeOfCargo; }
            set
            {
                typeOfCargo = value;
                OnPropertyChanged("TypeOfCargo");
            }
        }

        private ObservableCollection<DeliveryModel> delivery;
        public ObservableCollection<DeliveryModel> Delivery
        {
            get { return delivery; }
            set
            {
                delivery = value;
                OnPropertyChanged("Delivery");
            }
        }

        private ObservableCollection<CourierModel> couriers;
        public ObservableCollection<CourierModel> Couriers
        {
            get { return couriers; }
            set
            {
                couriers = value;
                OnPropertyChanged("Couriers");
            }
        }

        CreateEditPage crEdPage;


        private RelayCommand createOrder;
        public RelayCommand CreateOrder
        {
            get
            {
                return createOrder ?? (createOrder = new RelayCommand(obj =>
                {
                    SelectedOrder = new OrderModel();
                    SelectedOrder.Deadline = DateTime.Now;
                    vmCrEd.SelectedOrder = selectedOrder;
                    vmCrEd.status = true;
                    navigation.Navigate(crEdPage);
                    navigation.ChangeVisibility(Visibility.Hidden);
                }));
            }
        }


        private RelayCommand editOrder;
        public RelayCommand EditOrder
        {
            get
            {
                return editOrder ?? (editOrder = new RelayCommand(obj =>
                {
                    if (selectedOrder != null)
                    {
                        vmCrEd.SelectedOrder = selectedOrder;
                        vmCrEd.status = false;
                        navigation.Navigate(crEdPage);
                        navigation.ChangeVisibility(Visibility.Hidden);
                    }
                }));
            }
        }

        VMOrderCreateEdit vmCrEd;


        private RelayCommand refresh;
        public RelayCommand Refresh
        {
            get
            {
                return refresh ?? (refresh = new RelayCommand(obj =>
                {
                    List<StatusModel> statuslist = dbOperations.GetAllStatuses();
                    List<OrderModel> orderlist = dbOperations.GetAllOrders();
                    List<CustomerModel> customerlist = dbOperations.GetAllCustomers();
                    List<TypeOfCargoModel> typeOfCargolist = dbOperations.GetAllTypesOfCargo();
                    List<DeliveryModel> deliverylist = dbOperations.GetAllDeliveries();
                    List<CourierModel> courierlist = dbOperations.GetAllCouriers();
                    Status = new ObservableCollection<StatusModel>(statuslist);
                    Orders = new ObservableCollection<OrderModel>(orderlist);
                    Customer = new ObservableCollection<CustomerModel>(customerlist);
                    TypeOfCargo = new ObservableCollection<TypeOfCargoModel>(typeOfCargolist);
                    Delivery = new ObservableCollection<DeliveryModel>(deliverylist);
                    Couriers = new ObservableCollection<CourierModel>(courierlist);
                    SelectedOrder = null;
                }));
            }
        }



        private RelayCommand deleteOrder;
        public RelayCommand DeleteOrder
        {
            get
            {
                return deleteOrder ?? (deleteOrder = new RelayCommand(obj =>
                {
                    if (selectedOrder != null)
                    {
                        dbOperations.DeleteOrder(selectedOrder.ID);
                        List<OrderModel> orderlist = dbOperations.GetAllOrders();
                        Orders = new ObservableCollection<OrderModel>(orderlist);
                        SelectedOrder = null;
                    }
                }));
            }
        }


        private RelayCommand searchOrder;
        public RelayCommand SearchOrder
        {
            get
            {
                return searchOrder ?? (searchOrder = new RelayCommand(obj =>
                {
                    List<string> keyWords = new List<string>();
                    string req = search;
                    if (req!=null)
                    {
                        keyWords.AddRange(req.Split(' '));
                        ObservableCollection<OrderModel> ord = new ObservableCollection<OrderModel>();
                        List<OrderModel> orderlist = dbOperations.GetAllOrders();
                        orders = new ObservableCollection<OrderModel>(orderlist);
                        foreach (OrderModel o in orders)
                        {
                            string order = ConstrStringOrder(o);
                            bool st = true;
                            for (int i = 0; i < keyWords.Count; i++)
                                if (!order.Contains(keyWords[i]))
                                {
                                    st = false;
                                    break;
                                }
                            if (st)
                                ord.Add(o);
                        }
                        Orders = ord;
                    }

                }));
            }
        }

        string ConstrStringOrder(OrderModel o)
        {
            string res;
            res = o.AddNote + o.AdressDestination + o.AdressOrigin + o.Cost + o.DeadlineS + o.ID + o.OrderDateS + o.Price + o.ReceiverName;
            var c = couriers.Where(i => i.ID == o.Courier_ID_FK).ToList();
            if (c.Count!=0)
            {
                string cour = c.First().CourierName;
                res = res + cour;
            }
            string stat = status.Where(i => i.ID == o.Status_ID_FK).ToList().First().StatusName;
            res = res + stat;
            string cust = customer.Where(i => i.ID == o.Customer_ID_FK).ToList().First().CustomerName;
            res = res + cust;
            string type = typeOfCargo.Where(i => i.ID == o.TypeOfCargo_ID_FK).ToList().First().TypeName;
            res = res + type;
            var d = delivery.Where(i => i.ID == o.Delivery_ID_FK).ToList();
            if (d.Count!=0)
            {
                string deldate = d.First().DateS;
                res = res + deldate;
            }
            return res;
        }


        private RelayCommand appointCourier;
        public RelayCommand AppointCourier
        {
            get
            {
                return appointCourier ?? (appointCourier = new RelayCommand(obj =>
                {
                    if (selectedOrder != null)
                    {
                        dbOperations.UpdateOrder(selectedOrder);
                    }
                }));
            }
        }

        private RelayCommand makeContract;
        public RelayCommand MakeContract
        {
            get
            {
                return makeContract ?? (makeContract = new RelayCommand(obj =>
                {
                    if (selectedOrder != null)
                    {
                        if (selectedOrder.Courier_ID_FK != 0 && selectedOrder.Courier_ID_FK != 1)
                            ContractCreation();
                    }
                }));
            }
        }

        void ContractCreation()
        {
            //создание контракта
        }


        public VMOrder()
        {
            navigation = IoC.Get<INavigation>();
            navigation.CurrentPageChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            navigation.VisibilityChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            dbOperations = BLL.ServiceModules.IoC.Get<IdbCrud>();
            List<StatusModel> statuslist = dbOperations.GetAllStatuses();
            List<OrderModel> orderlist = dbOperations.GetAllOrders();
            List<CustomerModel> customerlist = dbOperations.GetAllCustomers();
            List<TypeOfCargoModel> typeOfCargolist = dbOperations.GetAllTypesOfCargo();
            List<DeliveryModel> deliverylist = dbOperations.GetAllDeliveries();
            List<CourierModel> courierlist = dbOperations.GetAllCouriers();
            Status = new ObservableCollection<StatusModel>(statuslist);
            Orders = new ObservableCollection<OrderModel>(orderlist);
            Customer = new ObservableCollection<CustomerModel>(customerlist);
            TypeOfCargo = new ObservableCollection<TypeOfCargoModel>(typeOfCargolist);
            Delivery = new ObservableCollection<DeliveryModel>(deliverylist);
            Couriers = new ObservableCollection<CourierModel>(courierlist);

            

            navigation = IoC.Get<INavigation>();
            navigation.CurrentPageChanged += (sender, e) => OnPropertyChanged(e.PropertyName);
            navigation.VisibilityChanged += (sender, e) => OnPropertyChanged(e.PropertyName);

            

            navigation.ChangeVisibility(Visibility.Hidden);

            vmCrEd = new VMOrderCreateEdit();

            crEdPage = new CreateEditPage(vmCrEd);
        }

    }
}
