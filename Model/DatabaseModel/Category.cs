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
        public string category_body { get; set; }
        public ICollection<Question> Questions { get; set; }

        public static implicit operator Task<object>(Category v)
        {
            throw new NotImplementedException();
        }
    }
}
