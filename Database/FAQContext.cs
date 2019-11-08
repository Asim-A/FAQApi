using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using FAQApi.Model;

namespace FAQApi.Database
{
    public class FAQContext : DbContext
    {
        public FAQContext(DbContextOptions<FAQContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Question> questions { get; set; }
        public DbSet<Answer> answers { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["FAQDatabase"].ConnectionString);
        //}
    }
}
