using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FAQApi.Database;
using FAQApi.Model.DatabaseModel;
using FAQApi.Services.FAQ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FAQApi.Controllers
{
    [Route("v1/faq/[controller]")]
    [ApiController]
    public class CustomerQuestionsController : Controller
    {

        private readonly FAQContext context;
        public CustomerQuestionsController(FAQContext context)
        {
            this.context = context;
        }

        // GET: v1/faq/CustomerQuestions
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: v1/faq/CustomerQuestions/5
        [HttpGet("{id}")]
        public string Get(int id)
        {



            return "value";
        }

        // POST: v1/faq/CustomerQuestions
        [HttpPost]
        public IActionResult Post([FromBody] CustomerQuestion newQuestion)
        {     
            
            for(int i = 0; i < 10; i++)
            {
                Debug.WriteLine("POST KJØRER!");
            }

            if (ModelState.IsValid)
            {
                for (int i = 0; i < 10; i++)
                {
                    Debug.WriteLine("GODKJENT!");
                }
                UnitOfWork unit = new UnitOfWork(context);

                unit.CustomerQuestion.Add(newQuestion);
                unit.Save();

                unit.Dispose();
                return StatusCode(201);
            }

            for (int i = 0; i < 10; i++)
            {
                Debug.WriteLine("IKKEGODKJENT!");
            }

            return StatusCode(400);

        }

    }
}
