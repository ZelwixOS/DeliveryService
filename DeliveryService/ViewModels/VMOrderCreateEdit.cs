using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class VMOrderCreateEdit : VMBase
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

        private OrderModel selectedOrder;
        public OrderModel SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                selectedOrder = value;

                List<CustomerModel> customerlist = dbOperations.GetAllCustomers();
                List<TypeOfCargoModel> typeOfCargolist = dbOperations.GetAllTypesOfCargo();
                List<CourierModel> courierlist = dbOperations.GetAllCouriers();

                customer = new ObservableCollection<CustomerModel>(customerlist);
                typeOfCargo = new ObservableCollection<TypeOfCargoModel>(typeOfCargolist);
                couriers = new ObservableCollection<CourierModel>(courierlist);

                OnPropertyChanged("SelectedOrder");
                Textst = " ";
            }
        }


        private ObservableCollection<TypeOfCargoModel> typeOfCargo;
        public ObservableCollection<TypeOfCargoModel> TypeOfCargo
        {
            get { return typeOfCargo; }
            set
            {
                typeOfCargo = value;
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


        private ObservableCollection<CustomerModel> customer;
        public ObservableCollection<CustomerModel> Customer
        {
            get { return customer; }
            set
            {
                customer = value;
                OnPropertyChanged();
            }
        }

        double SumCount()
        {
            CustomerModel cl = dbOperations.GetClient(selectedOrder.Customer_ID_FK);
            TypeOfCargoModel tc = dbOperations.GetTypeOfCargo(selectedOrder.TypeOfCargo_ID_FK);
            return (selectedOrder.Price + selectedOrder.Price * (tc.Coefficient/100) )* (100 - cl.Discount)/100;
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
                        selectedOrder.Cost = SumCount();
                        selectedOrder.OrderDate = DateTime.Now;
                        if (selectedOrder.Courier_ID_FK != 0 && selectedOrder.Courier_ID_FK != 1)
                            selectedOrder.Status_ID_FK = 2;
                        else
                            selectedOrder.Status_ID_FK = 1;

                        selectedOrder.UpdateDates();
                        if ((selectedOrder.AdressDestination==null)||(selectedOrder.AdressOrigin==null)||(selectedOrder.Price==0)||(selectedOrder.Customer_ID_FK==0)||(selectedOrder.Deadline==null)||(selectedOrder.ReceiverName==null)||(selectedOrder.TypeOfCargo_ID_FK==0))
                        {
                            Textst = "Введите данные";
                        }
                        else
                        {
                            selectedOrder.ID= dbOperations.CreateOrder(selectedOrder);
                            status = false;
                            Textst = "Заказ создан";
                        }  
                    }
                    else
                    {
                        selectedOrder.Cost = SumCount();
                        selectedOrder.UpdateDates();
                        dbOperations.UpdateOrder(selectedOrder);
                        Textst = "Заказ обновлён";
                    }
                },
                    (obj) => ((selectedOrder!=null)&&(selectedOrder.AdressDestination != null) && (selectedOrder.AdressOrigin != null) && (selectedOrder.Price != 0) && (selectedOrder.Customer_ID_FK != 0) && (selectedOrder.Deadline != null) && (selectedOrder.ReceiverName != null) && (selectedOrder.TypeOfCargo_ID_FK != 0)&& (selectedOrder.OrderName != null))));
            }
        }



        public VMOrderCreateEdit()
        {
            status = true;
            dbOperations = BLL.ServiceModules.IoC.Get<IdbCrud>();
            

            List<CustomerModel> customerlist = dbOperations.GetAllCustomers();
            List<TypeOfCargoModel> typeOfCargolist = dbOperations.GetAllTypesOfCargo();
            List<CourierModel> courierlist = dbOperations.GetAllCouriers();


            customer = new ObservableCollection<CustomerModel>(customerlist);
            typeOfCargo = new ObservableCollection<TypeOfCargoModel>(typeOfCargolist);
            couriers = new ObservableCollection<CourierModel>(courierlist);

            
        }

    }
}
