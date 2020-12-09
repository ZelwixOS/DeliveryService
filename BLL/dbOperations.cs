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
        #endregion

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
