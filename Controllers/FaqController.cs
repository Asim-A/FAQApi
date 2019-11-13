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
using Newtonsoft.Json;

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
        public string Get()
        {
            

            //List<Subcategory> s =
            //    context.subcategories.Where(sc => sc.Category.category_id == 1)
            //    .Include(sc => sc.Questions)
            //    .ToList();

            List<Category> v =
                context.categories
                .Include(catagories => catagories.Subcategories)
                .ThenInclude(sc => sc.Questions)
                .ToList();

            string ss = JsonConvert.SerializeObject(v);

            return ss;
            
        }

        public void generateTestSet()
        {
            ICollection<Question> q = new List<Question>();
            ICollection<Question> q2 = new List<Question>();

            ICollection<Subcategory> subcats = new List<Subcategory>();

            foreach (var item in questions)
            {

                var d = new Question
                {
                    question_body = item
                };

                q.Add(d);

            }

            q2.Add(new Question
            {
                question_body = "HVA SKJER MED VY?!"
            });

            Subcategory s1 = new Subcategory
            {
                subcategory_title = "Buss",
                Questions = q
            };

            Subcategory s2 = new Subcategory
            {
                subcategory_title = "VY!",
                Questions = q2
            };

            subcats.Add(s1);
            subcats.Add(s2);



            Category category = new Category
            {
                category_body = "Diverse",
                Subcategories = subcats
            };

            context.categories.Add(category);
            context.SaveChanges();
        }



    }
}
