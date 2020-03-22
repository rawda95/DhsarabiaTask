using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DhsarabiaTask.Data.Models
{
   public class DhsarabiaTaskContext : DbContext
    {

        public IConfiguration Configuration { get; }

        public DhsarabiaTaskContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public DhsarabiaTaskContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DhsarabiaTaskDB"));
            }
        }
    }
}
