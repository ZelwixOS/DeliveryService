  namespace DAL.Interfaces
{
    public interface IdbOperations
    {
        IRepository<Courier> Couriers { get; }
        IRepository<Customer> Customers { get; }
        IRepository<Delivery> Deliveries { get; }
        IRepository<Order> Orders { get; }
        IRepository<Status> Statuses { get; }
        IRepository<Transport> Transports { get; }
        IRepository<TypeOfCargo> TypesOfCargo { get; }
        int Save();
    }
}
