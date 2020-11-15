namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Delivery")]
    public partial class Delivery
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Delivery()
        {
            Order = new HashSet<Order>();
        }

        public int ID { get; set; }

        public double Distance { get; set; }

        public double KmPrice { get; set; }

        public int Courier_ID_FK { get; set; }

        public int? Transport_ID_FK { get; set; }

        public DateTime Date { get; set; }

        public virtual Courier Courier { get; set; }

        public virtual Transport Transport { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
