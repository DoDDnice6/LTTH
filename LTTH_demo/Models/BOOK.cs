namespace LTTH_demo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOOK")]
    public partial class BOOK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BOOK()
        {
            ISSUEs = new HashSet<ISSUE>();
        }

        public long ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? AuthorID { get; set; }

        public int? PublishID { get; set; }

        public decimal? Price { get; set; }

        public int? NumberPage { get; set; }

        public int? CategoryID { get; set; }

        [StringLength(500)]
        public string Note { get; set; }

        public virtual AUTHOR AUTHOR { get; set; }

        public virtual CATEGORY CATEGORY { get; set; }

        public virtual PUBLISHING PUBLISHING { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ISSUE> ISSUEs { get; set; }
    }
}
