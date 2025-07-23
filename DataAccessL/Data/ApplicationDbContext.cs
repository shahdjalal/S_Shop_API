using Microsoft.EntityFrameworkCore;
using Shahd_DataAccessL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_DataAccessL.Data
{
  public  class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categoties { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
        {
        }
    }
}
