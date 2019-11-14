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




    }
}
