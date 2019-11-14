using FAQApi.Database;
using FAQApi.Model.DatabaseModel;
using Microsoft.EntityFrameworkCore;
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
    }
}
