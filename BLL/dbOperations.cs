using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using BLL.Models;

namespace BLL
{
    public class dbOperations : IdbCrud
    {
        IdbOperations db;

        public dbOperations(IdbOperations repos)
        {
            db = repos;
        }

        #region Order
        public List<OrderModel> GetAllOrders()
        {
            return db.Orders.GetList().Select(i => new OrderModel(i)).ToList();
        }

        public void CreateOrder(OrderModel o)
        {
            db.Orders.Create(new Order() { AddNote = o.AddNote, AdressDestination = o.AdressDestination, AdressOrigin = o.AdressOrigin, Cost = o.Cost, Courier_ID_FK = o.Courier_ID_FK, Customer_ID_FK = o.Customer_ID_FK, Deadline = o.Deadline, Delivery_ID_FK = o.Delivery_ID_FK, OrderDate = o.OrderDate, Price = o.Price, ReceiverName = o.ReceiverName, Status_ID_FK = o.Status_ID_FK, TypeOfCargo_ID_FK = o.TypeOfCargo_ID_FK });
            Save();
        }

        public void UpdateOrder(OrderModel o)
        {
            Order ord = db.Orders.GetItem(o.ID);
            ord.AddNote = o.AddNote;
            ord.AdressDestination = o.AdressDestination;
            ord.AdressOrigin = o.AdressOrigin;
            ord.Cost = o.Cost;
            ord.Courier_ID_FK = o.Courier_ID_FK;
            ord.Customer_ID_FK = o.Customer_ID_FK;
            ord.Deadline = o.Deadline;
            ord.Delivery_ID_FK = o.Delivery_ID_FK;
            ord.OrderDate = o.OrderDate;
            ord.Price = o.Price;
            ord.ReceiverName = o.ReceiverName;
            ord.Status_ID_FK = o.Status_ID_FK;
            ord.TypeOfCargo_ID_FK = o.TypeOfCargo_ID_FK;
            db.Orders.Update(ord);
            Save();
        }

        public void DeleteOrder(int id)
        {
            Order ord = db.Orders.GetItem(id);
            if (ord!=null)
            {
                db.Orders.Delete(ord.ID);
                Save();
            }
        }
        #endregion


        #region Status
        public List<StatusModel> GetAllStatuses()
        {
            return db.Statuses.GetList().Select(i=> new StatusModel(i)).ToList();
        }

        public void CreateStatus(StatusModel s)
        {
            db.Statuses.Create(new Status() { StatusName = s.StatusName });
            Save();
        }

        public void UpdateStatus(StatusModel s)
        {
            Status st = db.Statuses.GetItem(s.ID);
            st.StatusName = s.StatusName;
            db.Statuses.Update(st);
            Save();
        }

        public void DeleteStatus(int id)
        {
            Status st = db.Statuses.GetItem(id);
            if (st != null)
            {
                db.Statuses.Delete(st.ID);
                Save();
            }
        }

        #endregion

        #region Customer
        public List<CustomerModel> GetAllCustomers()
        {
            return db.Customers.GetList().Select(i => new CustomerModel(i)).ToList();
        }

        public CustomerModel GetClient(int id)
        {
            CustomerModel cl = new CustomerModel(db.Customers.GetItem(id));
            return cl;
        }

        public void CreateCustomer(CustomerModel c)
        {
            db.Customers.Create(new Customer() { CustomerName = c.CustomerName, Discount=c.Discount });
            Save();
        }

        public void UpdateCustomer(CustomerModel c)
        {
            Customer cl = db.Customers.GetItem(c.ID);
            cl.Discount = c.Discount;
            cl.CustomerName = c.CustomerName;
            db.Customers.Update(cl);
            Save();
        }
        public void DeleteCustomer(int id)
        {
            Customer cl = db.Customers.GetItem(id);
            if (cl != null)
            {
                db.Customers.Delete(cl.ID);
                Save();
            }
        }

        #endregion

        #region TypeOfCargo

        public List<TypeOfCargoModel> GetAllTypesOfCargo()
        {
            return db.TypesOfCargo.GetList().Select(i => new TypeOfCargoModel(i)).ToList();
        }

        public void CreateCargoType(TypeOfCargoModel t)
        {
            db.TypesOfCargo.Create(new TypeOfCargo() { TypeName=t.TypeName, Coefficient=t.Coefficient  });
            Save();
        }

        public void UpdateCargoType(TypeOfCargoModel t)
        {
            TypeOfCargo ct = db.TypesOfCargo.GetItem(t.ID);
            ct.TypeName = t.TypeName;
            ct.Coefficient = t.Coefficient;
            db.TypesOfCargo.Update(ct);
            Save();
        }

        public void DeleteCargoType(int id)
        {
            TypeOfCargo ct = db.TypesOfCargo.GetItem(id);
            if (ct != null)
            {
                db.TypesOfCargo.Delete(ct.ID);
                Save();
            }
        }

        #endregion

        #region Delivery

        public List<DeliveryModel> GetAllDeliveries()
        {
            return db.Deliveries.GetList().Select(i => new DeliveryModel(i)).ToList();
        }

        public TypeOfCargoModel GetTypeOfCargo(int id)
        {
            TypeOfCargoModel tc = new TypeOfCargoModel(db.TypesOfCargo.GetItem(id));
            return tc;
        }
        #endregion


        #region Courier

        public List<CourierModel> GetAllCouriers()
        {
            return db.Couriers.GetList().Select(i => new CourierModel(i)).ToList();
        }

        public void CreateCourier(CourierModel c)
        {
            db.Couriers.Create(new Courier() { CourierName = c.CourierName, PhoneNumber = c.PhoneNumber });
            Save();
        }

        public void UpdateCourier(CourierModel c)
        {
            Courier cr = db.Couriers.GetItem(c.ID);
            cr.CourierName = c.CourierName;
            cr.PhoneNumber = c.PhoneNumber;
            db.Couriers.Update(cr);
            Save();
        }
        public void DeleteCourier(int id)
        {
            Courier cr = db.Couriers.GetItem(id);
            if (cr != null)
            {
                db.Couriers.Delete(cr.ID);
                Save();
            }
        }

        #endregion

        #region Transport

        public List<TransportModel> GetAllCars()
        {
            return db.Transports.GetList().Select(i => new TransportModel(i)).ToList();
        }

        public void CreateCar(TransportModel t)
        {
            db.Transports.Create(new Transport() { TransportName =t.TransportName, Number=t.Number });
            Save();
        }

        public void UpdateCar(TransportModel t)
        {
            Transport tr = db.Transports.GetItem(t.ID);
            tr.TransportName = t.TransportName;
            tr.Number = t.TransportName;
            db.Transports.Update(tr);
            Save();
        }
        public void DeleteCar(int id)
        {
            Transport tr = db.Transports.GetItem(id);
            if (tr != null)
            {
                db.Transports.Delete(tr.ID);
                Save();
            }
        }


        #endregion


        public int Save()
        {
            int SaveCh = 0;
            try
            {
                SaveCh = db.Save();
            }
            catch (Exception e)
            {
                return 2;
            }
            if (SaveCh > 0) return 1;
            return 0;
        }

    }
}
