using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shahd_DataAccessL.Data;
using Shahd_DataAccessL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_DataAccessL.Utils
{
    public class SeedData : ISeedData
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public SeedData(ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }


        public async Task DataSeedingAsync()
        {
            if ((await _context.Database.GetPendingMigrationsAsync()).Any())
            {
              await  _context.Database.MigrateAsync();
            }
            if (! await _context.Categoties.AnyAsync())
            {
             await   _context.Categoties.AddRangeAsync(
                    new Category { Name = "clothes"},
                     new Category { Name = "mobiles" }

                    );
            }

            if (! await _context.Brands.AnyAsync())
            {
               await _context.Brands.AddRangeAsync(
                    new Brand { Name = "Samsung" },
                     new Brand { Name = "Apple" }

                    );
            }

            await _context.SaveChangesAsync();

        }

        public async Task IdentityDataSeedingAsync()
        {
         if (! await _roleManager.Roles.AnyAsync())
            {
              await  _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
                await _roleManager.CreateAsync(new IdentityRole("Customer"));
            }

            if (!await _userManager.Users.AnyAsync())
            {
                var user1 = new ApplicationUser()
                {
                    Email="shahd@gmail.com",
                    FullName = "shahd jalal",
                    PhoneNumber="05848664556",
                    UserName="sjalal",
                    EmailConfirmed=true
                    
                 };
                var user2 = new ApplicationUser()
                {
                    Email = "ahmad@gmail.com",
                    FullName = "ahmad jalal",
                    PhoneNumber = "05848664556",
                    UserName = "Ahmad",
                    EmailConfirmed = true

                };

                var user3 = new ApplicationUser()
                {
                    Email = "jana@gmail.com",
                    FullName = "jana jalal",
                    PhoneNumber = "05848664556",
                    UserName = "jana",
                    EmailConfirmed = true

                };

                await _userManager.CreateAsync(user1,"Pass@212345");
                await _userManager.CreateAsync(user2, "Pass@212345");
                await _userManager.CreateAsync(user3, "Pass@212345");

                await _userManager.AddToRoleAsync(user1, "Admin");
                await _userManager.AddToRoleAsync(user2, "SuperAdmin");
                await _userManager.AddToRoleAsync(user3, "Customer");
            }

            await _context.SaveChangesAsync();



        }
    }
}
