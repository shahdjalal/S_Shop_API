using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shahd_DataAccessL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_DataAccessL.Data
{
  public  class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categoties { get; set; }

        public DbSet<Product> Products { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //في حال بدي اغير اسماء الجداول
            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");

            //ignore
            builder.Ignore<IdentityUserClaim<string>>();
            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityUserToken<string>>();
            builder.Ignore<IdentityRoleClaim<string>>();
        }
    }
}
