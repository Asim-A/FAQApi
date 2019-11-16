using System;
using FAQApi.Database;
using FAQApi.Services.FAQ;
using Microsoft.AspNetCore.Mvc;

namespace FAQApi.Controllers
{
    [Route("v1/faq/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {

        private readonly FAQContext context;
        public CategoriesController(FAQContext context)
        {
            this.context = context;
        }

        // GET: v1/faq/Categories
        [HttpGet]
        public string Get()
        {
            UnitOfWork unitOfWork = new UnitOfWork(context);
            string s = unitOfWork.Categories.GetAllJSON();

            unitOfWork.Dispose();
            return s;
        }

        // GET: v1/faq/Categories/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            UnitOfWork unit = new UnitOfWork(context);
            string s = unit.Categories.GetIncludeJSON(id);
            
            unit.Dispose();
            return s;
        }

        // GET: v1/faq/Categories/GetAll
        //Brukes for testing av all data i databasen.
        [HttpGet]
        [Route("GetAll")]  
        public string GetAll()
        {
            UnitOfWork unit = new UnitOfWork(context);
            string all = unit.Categories.GetAllIncludedJSON();
            
            unit.Dispose();
            return all;
        }

        // Brukes ikke
        // POST: v1/faq/Categories
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // Brukes ikke
        // PUT: v1/faq/Categories/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // Brukes ikke
        // DELETE: v1/faq/Categories/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
