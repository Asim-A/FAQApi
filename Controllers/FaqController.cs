using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FAQApi.Database;
using FAQApi.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FAQApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class FaqController : ControllerBase
    {
        private readonly FAQContext context;
        public FaqController(FAQContext context)
        {
            this.context = context;
        }


        private static readonly string[] questions = new[]
        {
            "Hvor ofte går bussen?",
            "Hvorfor går bussen nå?",
            "Hva er vy?"
        };

        // GET: /<controller>/
        [HttpGet]
        public IEnumerable<Question> Get()
        {

            context.questions.Add(new Question
            {
                question_id = 9999,
                question_body = "TEST BODY"
            });

            return Enumerable.Range(0, questions.Length).Select(i => new Question { 
                question_id = i,
                question_body = questions[i]
            });
        }

        


    }
}
