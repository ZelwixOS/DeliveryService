using System;


namespace BLL.Models
{
    public class DeliveryModelModel
    {
        public int ID { get; set; }

        public double Distance { get; set; }

        public double KmPrice { get; set; }

        public int Courier_ID_FK { get; set; }

        public int? Transport_ID_FK { get; set; }

        public DateTime Date { get; set; }
    }
}
