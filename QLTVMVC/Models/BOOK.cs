namespace QLTVMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOOK")]
    public partial class BOOK
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Author { get; set; }

        public int? PublishID { get; set; }

        public decimal? Price { get; set; }

        public int? NumberPage { get; set; }

        public int? CategoryID { get; set; }

        [StringLength(500)]
        public string Note { get; set; }

        public virtual PUBLISHING PUBLISHING { get; set; }
    }
}
