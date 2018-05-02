using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LTTH_demo.Models.DTO
{
    public class BOOKdto
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Author { get; set; }
        [StringLength(50)]
        public string Publish { get; set; }

        public decimal? Price { get; set; }

        public int? NumberPage { get; set; }

        public string Category { get; set; }

        [StringLength(500)]
        public string Note { get; set; }
    }
}