using System;
using DAL;

namespace BLL.Models
{
    public class DeliveryModel
    {
        public int ID { get; set; }

        public double Distance { get; set; }

        public double KmPrice { get; set; }

        public int Courier_ID_FK { get; set; }

        public int? Transport_ID_FK { get; set; }

        public DateTime Date { get; set; }

        public DeliveryModel(Delivery d)
        {
            ID = d.ID;
            Distance = d.Distance;
            KmPrice = d.KmPrice;
            Courier_ID_FK = d.Courier_ID_FK;
            Transport_ID_FK = d.Transport_ID_FK;
            Date = d.Date;
        }
    }
}
