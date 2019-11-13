using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FAQApi.Model.DatabaseModel
{
    public class Question
    {

        [Key]
        public int question_id { get; set; }
        public string question_body { get; set; }

        public int question_likes { get; set; } = 0;
        public int question_dislikes { get; set; } = 0;
 
        public Subcategory Subcategory { get; set; }
        
        public string answer { get; set; }

    }
}
