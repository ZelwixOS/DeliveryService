using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IdbCrud
    {
        List<OrderModel> GetAllOrders();

        List<StatusModel> GetAllStatuses();

        List<CustomerModel> GetAllCustomers();

        List<TypeOfCargoModel> GetAllTypesOfCargo();

        List<DeliveryModel> GetAllDeliveries();

        List<CourierModel> GetAllCouriers();

        List<TransportModel> GetAllCars();

        void CreateOrder(OrderModel o);

        void UpdateOrder(OrderModel o);
        void DeleteOrder(int id);

        CustomerModel GetClient(int id);

        TypeOfCargoModel GetTypeOfCargo(int id);

        int Save();
    }
}
