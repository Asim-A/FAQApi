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

        public Category Category { get; set; }
        
        public string answer { get; set; }

    }
}
