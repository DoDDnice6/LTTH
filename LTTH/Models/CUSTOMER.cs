namespace LTTH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CUSTOMER")]
    public partial class CUSTOMER
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Sex { get; set; }

        [StringLength(50)]
        public string Image { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CardCreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CardExpiredDate { get; set; }

        [StringLength(500)]
        public string Note { get; set; }
    }
}
