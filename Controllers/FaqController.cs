using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FAQApi.Database;
using FAQApi.Model.DatabaseModel;
using FAQApi.Model.DTOModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FAQApi.Controllers
{
    [ApiController]
    [Route("/v1/[controller]")]
    public class FaqController : Controller
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

            //context.questions.Add(new Question
            //{
            //    question_body = "TEST BODY"
            //});

            ICollection<Question> q = new List<Question>();

            foreach(var item in questions)
            {

                var d = new Question
                {
                    question_body = item
                };

                q.Add(d);

            }

            Category category = new Category
            {
                category_body = "Diverse",
                Questions = q
            };

            context.categories.Add(category);

            context.SaveChanges();

            List<Question> s = 
                context.questions.Where(x => x.Category.category_id == 1).ToList();


            return s;
            

            //return Enumerable.Range(0, questions.Length).Select(i => new Question { 
            //    question_id = i,
            //    question_body = questions[i]
            //});
        }


        


    }
}
