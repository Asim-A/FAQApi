﻿using FAQApi.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAQApi.Services
{
    public interface IQuestionRepository : IRepository<Question>
    {
        public string GetQuestionsBySubcategory(int id);
    }
}
