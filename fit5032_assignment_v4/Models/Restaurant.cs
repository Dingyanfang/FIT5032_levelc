namespace fit5032_assignment_v4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Restaurant")]
    public partial class Restaurant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Restaurant()
        {
            Appointments = new HashSet<Appointment>();
            Dishes = new HashSet<Dish>();
        }

        public int RestaurantId { get; set; }

        public int OwnerId { get; set; }

        [Required]
        public string RestaurantName { get; set; }

        [Required]
        public string RestaurantDesc { get; set; }

        [Required]
        public string RestaurantCountry { get; set; }

        [Required]
        public string RestaurantState { get; set; }

        [Required]
        public string RestaurantCity { get; set; }

        [Required]
        public string RestaurantSuburb { get; set; }

        [Required]
        public string RestaurantStreet { get; set; }

        [Required]
        public string RestaurantPostcode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dish> Dishes { get; set; }

        public virtual RestaurantOwner RestaurantOwner { get; set; }
    }
}
