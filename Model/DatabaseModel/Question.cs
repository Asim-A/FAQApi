using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FAQApi.Model.DatabaseModel
{
    public class Question
    {

        [Key]
        public int question_id { get; set; }
        public string question_body { get; set; }
        public ICollection<Answer>? answers { get; set; }

    }
}
