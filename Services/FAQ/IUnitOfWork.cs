using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAQApi.Services
{
    interface IUnitOfWork : IDisposable
    {

        ICategoryRepository Categories { get; }
        ISubcategoryRepository Subcategories { get;  }
        IQuestionRepository Questions { get; }

        int Save();
    }
}
