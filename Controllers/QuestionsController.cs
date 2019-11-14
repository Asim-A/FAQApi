using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FAQApi.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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



    }
}