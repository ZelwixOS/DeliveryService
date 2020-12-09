namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public int ID { get; set; }

        public double Price { get; set; }

        public double Cost { get; set; }

        [Required]
        [StringLength(50)]
        public string AdressOrigin { get; set; }

        public int? Delivery_ID_FK { get; set; }

        public int TypeOfCargo_ID_FK { get; set; }

        public int Customer_ID_FK { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime Deadline { get; set; }

        [Required]
        [StringLength(50)]
        public string AdressDestination { get; set; }

        [Required]
        [StringLength(50)]
        public string ReceiverName { get; set; }

        [StringLength(50)]
        public string AddNote { get; set; }

        public int Status_ID_FK { get; set; }

        public int? Courier_ID_FK { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Delivery Delivery { get; set; }

        public virtual Status Status { get; set; }

        public virtual TypeOfCargo TypeOfCargo { get; set; }

        public virtual Courier Courier { get; set; }
    }
}
