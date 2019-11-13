using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using FAQApi.Model.DatabaseModel;

namespace FAQApi.Database
{
    public class FAQContext : DbContext
    {
        public FAQContext(DbContextOptions<FAQContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Category> categories { get; set; }
        public DbSet<Subcategory> subcategories { get; set; }
        public DbSet<Question> questions { get; set; }

    }
}
