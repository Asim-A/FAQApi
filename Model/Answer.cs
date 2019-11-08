
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FAQApi.Model
{
    public class Answer
    {
        
        [Key]
        public int answer_id { get; set; }
        public string answer_body { get; set; }
        public Question? answer_parent { get; set; }
       


    }
}
