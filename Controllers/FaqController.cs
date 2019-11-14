using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FAQApi.Database;
using FAQApi.Model.DatabaseModel;
using FAQApi.Model.DTOModel;
using FAQApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FAQApi.Controllers
{
    
    [Route("/v1/[controller]")]
    [ApiController]
    public class FaqController : Controller
    {
        private readonly FAQContext context;
        public FaqController(FAQContext context)
        {
            this.context = context;
        }

        // GET: /<controller>/
        [HttpGet]
        public string Get() { 

            string ss = new CategoryRepository(context).GetIncludeJSON(1);

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
