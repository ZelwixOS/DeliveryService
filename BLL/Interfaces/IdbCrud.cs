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


        int Save();
    }
}
