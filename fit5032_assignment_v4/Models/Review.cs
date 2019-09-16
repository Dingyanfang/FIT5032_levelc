namespace fit5032_assignment_v4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Review")]
    public partial class Review
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RestaurantId { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public string ReviewDesc { get; set; }

        public int ReviewRate { get; set; }

        public virtual Appointment Appointment { get; set; }
    }
}
