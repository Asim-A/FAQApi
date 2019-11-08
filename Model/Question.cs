using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAQApi.Model
{
    public class Question
    {

        public int question_id { get; set; }
        public string question_body { get; set; }
        public ICollection<Answer> answers { get; set; }

    }
}
