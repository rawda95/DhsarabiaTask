using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DhsarabiaTask.Data.Models
{
   public class DhsarabiaTaskContext : DbContext
    {

        public DhsarabiaTaskContext(DbContextOptions<DhsarabiaTaskContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
