namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DSdb : DbContext
    {
        public DSdb()
            : base("name=DSdb")
        {
        }

        public virtual DbSet<Courier> Courier { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Delivery> Delivery { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Transport> Transport { get; set; }
        public virtual DbSet<TypeOfCargo> TypeOfCargo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courier>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength();

            modelBuilder.Entity<Courier>()
                .HasMany(e => e.Delivery)
                .WithRequired(e => e.Courier)
                .HasForeignKey(e => e.Courier_ID_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.Customer_ID_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Delivery>()
                .HasMany(e => e.Order)
                .WithOptional(e => e.Delivery)
                .HasForeignKey(e => e.Delivery_ID_FK);

            modelBuilder.Entity<Status>()
                .Property(e => e.StatusName)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Status)
                .HasForeignKey(e => e.Status_ID_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transport>()
                .HasMany(e => e.Delivery)
                .WithOptional(e => e.Transport)
                .HasForeignKey(e => e.Transport_ID_FK);

            modelBuilder.Entity<TypeOfCargo>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.TypeOfCargo)
                .HasForeignKey(e => e.TypeOfCargo_ID_FK)
                .WillCascadeOnDelete(false);
        }
    }
}
