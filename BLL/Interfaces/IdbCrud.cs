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

        CustomerModel GetClient(int id);

        TypeOfCargoModel GetTypeOfCargo(int id);


        void CreateOrder(OrderModel o);

        void UpdateOrder(OrderModel o);
        void DeleteOrder(int id);


        void CreateCustomer(CustomerModel c);

        void UpdateCustomer(CustomerModel c);
        void DeleteCustomer(int id);


        void CreateCourier(CourierModel c);

        void UpdateCourier(CourierModel c);
        void DeleteCourier(int id);


        void CreateCar(TransportModel t);

        void UpdateCar(TransportModel t);
        void DeleteCar(int id);

        void CreateCargoType(TypeOfCargoModel t);

        void UpdateCargoType(TypeOfCargoModel t);
        void DeleteCargoType(int id);


        void CreateStatus(StatusModel s);

        void UpdateStatus(StatusModel s);
        void DeleteStatus(int id);

        int Save();
    }
}
