using FAQApi.Database;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAQApi.Services.FAQ
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FAQContext _context;
        public ICategoryRepository Categories { get; private set; }
        public ISubcategoryRepository Subcategories { get; private set; }
        public IQuestionRepository Questions { get; private set; }

        public UnitOfWork(FAQContext context)
        {
            _context = context;
            Categories = new CategoryRepository(_context);
        }


        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
