using DAL.Interfaces;

namespace DAL.Repositories
{
    public class dbOperations : IdbOperations
    {
        private DSdb db;
        private CourierRepository courierRepository;
        private CustomerRepository customerRepository;
        private DeliveryRepository deliveryRepository;
        private OrderRepository orderRepository;
        private StatusRepository statusRepository;
        private TransportRepository transportRepository;
        private TypeOfCargoRepository typeOfCargoRepository;
         
        public dbOperations()
        {
            db = new DSdb();
        }

        public IRepository<Courier> Couriers
        {
            get
            {
                if (courierRepository == null)
                    courierRepository = new CourierRepository(db);
                return courierRepository;
            }
        }
        public IRepository<Customer> Customers
        {
            get
            {
                if (customerRepository == null)
                    customerRepository = new CustomerRepository(db);
                return customerRepository;
            }
        }
        public IRepository<Delivery> Deliveries
        {
            get
            {
                if (deliveryRepository == null)
                    deliveryRepository = new DeliveryRepository(db);
                return deliveryRepository;
            }
        }
        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }
        public IRepository<Status> Statuses
        {
            get
            {
                if (statusRepository == null)
                    statusRepository = new StatusRepository(db);
                return statusRepository;
            }
        }
        public IRepository<Transport> Transports
        {
            get
            {
                if (transportRepository == null)
                    transportRepository = new TransportRepository(db);
                return transportRepository;
            }
        }
        public IRepository<TypeOfCargo> TypesOfCargo
        {
            get
            {
                if (typeOfCargoRepository == null)
                    typeOfCargoRepository = new TypeOfCargoRepository(db);
                return typeOfCargoRepository;
            }
        }

        public int Save()
        {
            return db.SaveChanges();
        }
    }
}
