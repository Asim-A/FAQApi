﻿using FAQApi.Database;
using FAQApi.Model.DatabaseModel;
using Microsoft.EntityFrameworkCore;
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

        public string GetJSON(int id)
        {
            return JsonConvert.SerializeObject(Get(id));
        }
        public string GetAllJSON()
        {
            return JsonConvert.SerializeObject(GetAll());
        }


        FAQContext getContext()
        {
            return (context as FAQContext);
        }

        public string GetIncludeJSON(int id)
        {
            string json;

            var item = getContext()
                        .categories
                        .Where(cat => cat.category_id == id)
                        .Include(catagory => catagory.Subcategories)
                            .ThenInclude(sc => sc.Questions);

            json = JsonConvert.SerializeObject(item);
            return json;
        }

        public string GetAllIncludedJSON()
        {
            string json;

            var list = getContext()
                        .categories
                        .Include(catagories => catagories.Subcategories)
                            .ThenInclude(sc => sc.Questions)
                        .ToList();
            json = JsonConvert.SerializeObject(list);

            return json;
        }
    }
}
