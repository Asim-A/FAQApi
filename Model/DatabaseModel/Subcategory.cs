using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FAQApi.Model.DatabaseModel
{
    public class Subcategory
    {

        [Key]
        public int subcategory_id { get; set; }
        public string? subcategory_title { get; set; }
        public Category Category { get; set; }
        public ICollection<Question> Questions { get; set; }


    }
}
