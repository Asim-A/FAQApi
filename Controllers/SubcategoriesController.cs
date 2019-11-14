using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FAQApi.Database;
using FAQApi.Services.FAQ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FAQApi.Controllers
{
    [Route("v1/faq/[controller]")]
    [ApiController]
    public class SubcategoriesController : Controller
    {
        private readonly FAQContext context;
        public SubcategoriesController(FAQContext context)
        {
            this.context = context;
        }
        // GET: api/Subcategories
        [HttpGet]
        public IEnumerable<string> Get()
        {
            UnitOfWork unit = new UnitOfWork(context);
            return new string[] { "value1", "value2" };
        }

        // GET: api/Subcategories/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Subcategories
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Subcategories/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
