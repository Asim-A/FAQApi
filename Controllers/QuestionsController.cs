using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FAQApi.Database;
using FAQApi.Model.DatabaseModel;
using FAQApi.Services.FAQ;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FAQApi.Controllers
{
    [Route("v1/faq/[controller]")]
    [ApiController]
    public class QuestionsController : Controller
    {

        private readonly FAQContext context;
        public QuestionsController(FAQContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public string Get()
        {
            return "";
        }


        /**
         * Fordi det blir sendt komplekse objekter, må request-en sende data i body (som json), ikke URI.
         * Hvis man prøver å endre en annen id enn selve request-en vil man få 400 Bad Request repons.
         */
        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] Question newQuestion)
        {
            if (id != newQuestion.question_id)
                return StatusCode(400);

            UnitOfWork unit = new UnitOfWork(context);
            unit.Questions.Update(newQuestion);
            unit.Save(); //nødvendig
            unit.Dispose();

            return StatusCode(201); //Status code for created
            
        }


    }
}