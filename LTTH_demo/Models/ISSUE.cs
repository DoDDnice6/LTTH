namespace LTTH_demo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ISSUE")]
    public partial class ISSUE
    {
        public long ID { get; set; }

        public int? CustomerID { get; set; }

        public int? EmployeeID { get; set; }

        public long? BookID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? IssueDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpiryDate { get; set; }

        public virtual BOOK BOOK { get; set; }

        public virtual CUSTOMER CUSTOMER { get; set; }

        public virtual EMPLOYEE EMPLOYEE { get; set; }
    }
}
