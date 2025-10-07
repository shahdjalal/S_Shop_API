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

        //public async Task IdentityDataSeedingAsync()
        //{
        // if (! await _roleManager.Roles.AnyAsync())
        //    {
        //      await  _roleManager.CreateAsync(new IdentityRole("Admin"));
        //        await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
        //        await _roleManager.CreateAsync(new IdentityRole("Customer"));
        //    }

        //    if (!await _userManager.Users.AnyAsync())
        //    {
        //        var user1 = new ApplicationUser()
        //        {
        //            Email="shahd@gmail.com",
        //            FullName = "shahd jalal",
        //            PhoneNumber="05848664556",
        //            UserName="sjalal",
        //            EmailConfirmed=true

        //         };
        //        var user2 = new ApplicationUser()
        //        {
        //            Email = "ahmad@gmail.com",
        //            FullName = "ahmad jalal",
        //            PhoneNumber = "05848664556",
        //            UserName = "Ahmad",
        //            EmailConfirmed = true

        //        };

        //        var user3 = new ApplicationUser()
        //        {
        //            Email = "jana@gmail.com",
        //            FullName = "jana jalal",
        //            PhoneNumber = "05848664556",
        //            UserName = "jana",
        //            EmailConfirmed = true

        //        };

        //        await _userManager.CreateAsync(user1,"Pass@212345");
        //        await _userManager.CreateAsync(user2, "Pass@212345");
        //        await _userManager.CreateAsync(user3, "Pass@212345");

        //        await _userManager.AddToRoleAsync(user1, "Admin");
        //        await _userManager.AddToRoleAsync(user2, "SuperAdmin");
        //        await _userManager.AddToRoleAsync(user3, "Customer");
        //    }

        //    await _context.SaveChangesAsync();



        //}

        public async Task IdentityDataSeedingAsync()
        {
            // 1) تأكيد كل Role لوحده (بدل if (!Roles.AnyAsync()))
            async Task EnsureRoleAsync(string roleName)
            {
                if (!await _roleManager.RoleExistsAsync(roleName))
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
            }

            await EnsureRoleAsync("Admin");
            await EnsureRoleAsync("SuperAdmin");
            await EnsureRoleAsync("Customer");

            // 2) دالة مساعدة: تنشئ/تصلّح المستخدم حتى لو كان موجود
            async Task EnsureUserAsync(string email, string userName, string fullName, string role)
            {
                var user = await _userManager.FindByEmailAsync(email);

                if (user == null)
                {
                    user = new ApplicationUser
                    {
                        Email = email,
                        UserName = userName,
                        FullName = fullName,
                        PhoneNumber = "05848664556",
                        EmailConfirmed = true
                    };

                    var create = await _userManager.CreateAsync(user, "Pass@212345");
                    if (!create.Succeeded)
                        throw new Exception("Failed creating user " + email + ": " +
                            string.Join("; ", create.Errors.Select(e => e.Description)));
                }
                else
                {
                    // تأكيد الإيميل وإزالة أي Lockout/فشل وتثبيت الـ Normalized
                    if (!user.EmailConfirmed) user.EmailConfirmed = true;
                    user.LockoutEnabled = false;
                    user.LockoutEnd = null;
                    user.AccessFailedCount = 0;
                    if (string.IsNullOrWhiteSpace(user.NormalizedEmail))
                        user.NormalizedEmail = email.ToUpperInvariant();
                    if (string.IsNullOrWhiteSpace(user.NormalizedUserName))
                        user.NormalizedUserName = userName.ToUpperInvariant();

                    await _userManager.UpdateAsync(user);

                    // إعادة ضبط كلمة المرور لقيمة معروفة (تحل مشكلة "invalid email or password")
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var reset = await _userManager.ResetPasswordAsync(user, token, "Pass@212345");
                    if (!reset.Succeeded)
                        throw new Exception($"Failed resetting password for {email}: " +
                            string.Join("; ", reset.Errors.Select(e => e.Description)));
                }

                // تأكيد الدور
                if (!await _userManager.IsInRoleAsync(user, role))
                {
                    var add = await _userManager.AddToRoleAsync(user, role);
                    if (!add.Succeeded)
                        throw new Exception($"Failed adding role {role} to {email}: " +
                            string.Join("; ", add.Errors.Select(e => e.Description)));
                }
            }

            // 3) المستخدمون المطلوبون (لاحظي: بدون if (!Users.AnyAsync()))
            await EnsureUserAsync("shahd@gmail.com", "sjalal", "shahd jalal", "Admin");
            await EnsureUserAsync("ahmad@gmail.com", "Ahmad", "ahmad jalal", "SuperAdmin");
            await EnsureUserAsync("jana@gmail.com", "jana", "jana jalal", "Customer");

            // تغييرات Identity تتم عبر UserManager/RoleManager، لكن بقاء السطر لا يضر
            await _context.SaveChangesAsync();
        }



    }
}
