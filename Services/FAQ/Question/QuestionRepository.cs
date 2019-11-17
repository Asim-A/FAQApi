using FAQApi.Database;
using FAQApi.Model.DatabaseModel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAQApi.Services
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        public QuestionRepository(FAQContext c) : base(c)
        {

            

        }

        public string GetQuestionsBySubcategory(int id)
        {
            string s;

            var list = getContext().questions.Where(q => q.Subcategory.subcategory_id == id).ToList();

            s = JsonConvert.SerializeObject(list);

            return s;
        }


        FAQContext getContext()
        {
            return (context as FAQContext);
        }
    }
}
