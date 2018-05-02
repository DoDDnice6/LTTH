namespace LTTH.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web.Http.Controllers;
    using System.Web.Http.ModelBinding;

    public class BookModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(BOOK))
            {
                return false;
            }
            BOOK result = JsonConvert.DeserializeObject<BOOK>
               (actionContext.Request.Content.ReadAsStringAsync().Result);
            bindingContext.Model = result;
            return true;
        }
    }

    [Table("BOOK")]
    [ModelBinder(typeof(BookModelBinder))]
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
        [JsonIgnore]
        public virtual PUBLISHING PUBLISHING { get; set; }
    }
}
