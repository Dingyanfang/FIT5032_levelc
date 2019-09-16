namespace fit5032_assignment_v4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RestaurantOwner")]
    public partial class RestaurantOwner
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RestaurantOwner()
        {
            Restaurants = new HashSet<Restaurant>();
        }

        [Key]
        public int OwnerId { get; set; }

        [Required(ErrorMessage = "Please enter owner name!")]
        public string OwnerName { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
