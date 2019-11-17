
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

//Brukes ikke fordi bare 1 svar per spørsmål
namespace FAQApi.Model.DatabaseModel
{
    public class Answer
    {
        
        [Key]
        public int answer_id { get; set; }
        public string answer_body { get; set; }

        public int question_id { get; set; }
        public Question Question { get; set; }
       


    }
}
