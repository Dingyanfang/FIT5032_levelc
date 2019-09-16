namespace fit5032_assignment_v4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dish")]
    public partial class Dish
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RestaurantId { get; set; }

        [Key]
        [Column(Order = 1)]
        public int DishName { get; set; }

        [Required]
        public string DishDesc { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
