using FAQApi.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAQApi.Services
{
    public interface ICategoryRepository : IRepository<Category>
    {

        string GetJSON(int id);
        string GetIncludeJSON(int id);
        string GetAllJSON();
        string GetAllIncludedJSON();
        public string GetWithQuestionID(int id);




    }
}
