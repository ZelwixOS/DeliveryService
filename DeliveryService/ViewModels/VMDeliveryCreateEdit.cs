using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class VMDeliveryCreateEdit : VMBase
    {
        private readonly IdbCrud dbOperations;

        public bool status;

        public string textst;

        public string Textst
        {
            get { return textst; }
            set
            {



                textst = value;
                OnPropertyChanged("textst");
            }
        }




        private DeliveryModel selectedDelivery;
        public DeliveryModel SelectedDelivery
        {
            get { return selectedDelivery; }
            set
            {
                Couriers = new ObservableCollection<CourierModel>(dbOperations.GetAllCouriers());
                Car = new ObservableCollection<TransportModel>(dbOperations.GetAllCars());
                selectedDelivery = value;
                Cour = value.Courier_ID_FK;

                OnPropertyChanged("SelectedDelivery");
            }
        }


        private DeliveryOrderTable selectedOrder;
        public DeliveryOrderTable SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
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



        private int cour;

        public int Cour
        {
            get { return cour; }
            set
            {
                cour = value;
                selectedDelivery.Courier_ID_FK = cour;

                List<OrderModel> o = dbOperations.GetAllOrders();
                Orders.Clear();
                foreach (OrderModel om in o)
                    if (selectedDelivery.Courier_ID_FK == om.Courier_ID_FK)
                    {
                        if (om.Status_ID_FK == 2)
                            Orders.Add(new DeliveryOrderTable(om, false));
                        if (om.Status_ID_FK == 1002 && om.Delivery_ID_FK == selectedDelivery.ID)
                            Orders.Add(new DeliveryOrderTable(om, true));
                    }

                OnPropertyChanged("Cour");
            }
        }


        private ObservableCollection<DeliveryOrderTable> orders;
        public ObservableCollection<DeliveryOrderTable> Orders
        {
            get { return orders; }
            set
            {
                orders = value;
                OnPropertyChanged();
            }
        }


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




        private RelayCommand createUpdateCommand;
        public RelayCommand CreateUpdateCommand
        {
            get
            {
                return createUpdateCommand ?? (createUpdateCommand = new RelayCommand(obj =>
                {
                    if (status)
                    {
                        selectedDelivery.UpdateDates();
                        selectedDelivery.ID = dbOperations.CreateDelivery(selectedDelivery);
                        status = false;
                        Textst = "Доставка оформлена";
                    }
                    else
                    {
                        selectedDelivery.UpdateDates();
                        dbOperations.UpdateDelivery(selectedDelivery);
                        Textst = "Доставка обновлена";
                    }
                    foreach (DeliveryOrderTable o in orders)
                    {
                        if (o.inDeliv)
                        {
                            o.order.Delivery_ID_FK = selectedDelivery.ID;
                            o.order.Status_ID_FK = 1002;

                        }
                        else
                        {
                            o.order.Delivery_ID_FK = null;
                            o.order.Status_ID_FK = 2;
                        }

                        dbOperations.UpdateOrder(o.order);
                        RecountDiscount(o.order);
                    }
                },
                    (obj) => ((selectedDelivery != null) && (selectedDelivery.Date != null) && (selectedDelivery.Distance != 0) && (selectedDelivery.KmPrice != 0) && (selectedDelivery.Courier_ID_FK != 1) && (selectedDelivery.Courier_ID_FK != 0))));
            }
        }

        void RecountDiscount(OrderModel o)
        {
            if (o.Cost >= 3000)
            {
                CustomerModel c = dbOperations.GetClient(o.Customer_ID_FK);
                List <OrderModel> allClientOrders = dbOperations.GetAllOrders().Where(i=>i.Customer_ID_FK == c.ID).ToList();
                double discount = 0.0;
                foreach(OrderModel or in allClientOrders)
                {
                    if (or.Cost >= 3000)
                        discount += 5;
                }
                if (discount > 20)
                    discount = 20;
                c.Discount = discount;
                dbOperations.UpdateCustomer(c);
            }
        }

        public VMDeliveryCreateEdit()
        {
            status = true;
            dbOperations = BLL.ServiceModules.IoC.Get<IdbCrud>();


            List<CourierModel> courierlist = dbOperations.GetAllCouriers();
            List<TransportModel> carlist = dbOperations.GetAllCars();

            Couriers = new ObservableCollection<CourierModel>(courierlist);
            Car = new ObservableCollection<TransportModel>(carlist);

            Orders = new ObservableCollection<DeliveryOrderTable>();


        }

    }

    public class DeliveryOrderTable
    {
        public bool inDeliv { get; set; }
        public OrderModel order { get; set; }

        public DeliveryOrderTable(OrderModel o, bool wasIn)
        {
            inDeliv = wasIn;
            order = o;
        }
    }
}
