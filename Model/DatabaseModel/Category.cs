using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FAQApi.Model.DatabaseModel
{
    public class Category
    {

        [Key]
        public int category_id { get; set; }
        public string category_title { get; set; }
        public string category_body { get; set; }
        public ICollection<Subcategory> Subcategories { get; set; }
           
    }
}
