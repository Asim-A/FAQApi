using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FAQApi.Model.DatabaseModel;

namespace FAQApi.Services
{
    interface IQuestionsRepository
    {

        Task<Question> GetQuestionAsync();    

    }
}
