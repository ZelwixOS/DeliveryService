namespace BLL.Models
{
    using System;   
    public partial class OrderModel
    {
        public int ID { get; set; }

        public double Price { get; set; }

        public double Cost { get; set; }

        public string AdressOrigin { get; set; }

        public int? Delivery_ID_FK { get; set; }

        public int TypeOfCargo_ID_FK { get; set; }

        public int Customer_ID_FK { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime Deadline { get; set; }

        public string AdressDestination { get; set; }

        public string ReceiverName { get; set; }

        public string AddNote { get; set; }

        public int Status_ID_FK { get; set; }
    }
}
