﻿using System;
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

namespace DeliveryService.ViewModels
{
    class VMOrder : VMBase
    {
        private readonly INavigation navigation;
        private readonly IdbCrud dbOperations;

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
                OnPropertyChanged();
            }
        }

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

        private ObservableCollection<DeliveryModel> delivery;
        public ObservableCollection<DeliveryModel> Delivery
        {
            get { return delivery; }
            set
            {
                delivery = value;
                OnPropertyChanged();
            }
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
            status = new ObservableCollection<StatusModel>(statuslist);
            orders = new ObservableCollection<OrderModel>(orderlist);
            customer = new ObservableCollection<CustomerModel>(customerlist);
            typeOfCargo = new ObservableCollection<TypeOfCargoModel>(typeOfCargolist);
            delivery = new ObservableCollection<DeliveryModel>(deliverylist);
        }

    }
}
