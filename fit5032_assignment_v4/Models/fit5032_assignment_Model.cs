namespace fit5032_assignment_v4.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class fit5032_assignment_Model : DbContext
    {
        public fit5032_assignment_Model()
            : base("name=fit5032_assignment_Model")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<RestaurantOwner> RestaurantOwners { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .HasOptional(e => e.Review)
                .WithRequired(e => e.Appointment);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Appointments)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Restaurant>()
                .HasMany(e => e.Appointments)
                .WithRequired(e => e.Restaurant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Restaurant>()
                .HasMany(e => e.Dishes)
                .WithRequired(e => e.Restaurant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RestaurantOwner>()
                .HasMany(e => e.Restaurants)
                .WithRequired(e => e.RestaurantOwner)
                .WillCascadeOnDelete(false);
        }
    }
}
