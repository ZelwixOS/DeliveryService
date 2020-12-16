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


        /*
               public List<MedicineModel> GetAllMedicines()
        {
            return db.Medicines.GetList().Select(i => new MedicineModel(i)).ToList();
        }

        public MedicineModel GetMedicine(int ID)
        {
            return new MedicineModel(db.Medicines.GetItem(ID));
        }

        public void CreateMedicine(MedicineModel m)
        {
            db.Medicines.Create(new Medicine() { Name = m.Name, Mode_of_application_ID_FK = m.Mode_of_application_ID_FK }); 
            Save();
            //db.Medicines.Attach(p);
        }

        public void UpdateMedicine(MedicineModel m)
        {
            Medicine med = db.Medicines.GetItem(m.Medicine_ID);
            med.Name = m.Name;
            med.Mode_of_application_ID_FK = m.Mode_of_application_ID_FK;
            db.Medicines.Update(med);
            Save();
        }

        public void DeleteMedicine(int ID)
        {
            Medicine med = db.Medicines.GetItem(ID);
            if (med != null)
            {
                db.Medicines.Delete(med.Medicine_ID);
                Save();
            }
        }
         */


        #region Status
        public List<StatusModel> GetAllStatuses()
        {
            return db.Statuses.GetList().Select(i=> new StatusModel(i)).ToList();
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

        #endregion

        #region TypeOfCargo

        public List<TypeOfCargoModel> GetAllTypesOfCargo()
        {
            return db.TypesOfCargo.GetList().Select(i => new TypeOfCargoModel(i)).ToList();
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
        #endregion

        #region Transport

        public List<TransportModel> GetAllCars()
        {
            return db.Transports.GetList().Select(i => new TransportModel(i)).ToList();
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
