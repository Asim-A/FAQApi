using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FAQApi.Model.DatabaseModel;
using Microsoft.EntityFrameworkCore;

namespace FAQApi.Services
{
    public class CustomerQuestionRepository : Repository<CustomerQuestion>, ICustomerQuestionRepository
    {
        public CustomerQuestionRepository(DbContext c) : base(c)
        {
        }
    }
}
