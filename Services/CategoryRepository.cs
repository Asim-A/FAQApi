using FAQApi.Database;
using FAQApi.Model.DatabaseModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAQApi.Services
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {

        public CategoryRepository(FAQContext context) : base(context) { }

        public string GetAllAsString()
        {
            return JsonConvert.SerializeObject(GetAll());
        }

    }
}
