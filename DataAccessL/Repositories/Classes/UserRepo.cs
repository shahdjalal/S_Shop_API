using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shahd_DataAccessL.Models;
using Shahd_DataAccessL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_DataAccessL.Repositories.Classes
{
    public class UserRepo : IUserRepo
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRepo(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<List<ApplicationUser>> GetAllAsync()
        {
           return await _userManager.Users.ToListAsync();

        }

        public async Task<ApplicationUser> GetByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<bool> BlockUserAsync(string userId,int days)
        {
          var  user= await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            user.LockoutEnd = DateTime.UtcNow.AddDays(days);

            var result= await _userManager.UpdateAsync(user);

            return result.Succeeded;
        }

        public async Task<bool> unBlockUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            user.LockoutEnd = null;

            var result = await _userManager.UpdateAsync(user);

            return result.Succeeded;
        }

        public async Task<bool> IsBlockedAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false;
            }  

            return user.LockoutEnd.HasValue && user.LockoutEnd > DateTime.UtcNow;
        }

        public async Task<bool> changeUserRoleAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user is null) return false;

            var currrntRoles = await _userManager.GetRolesAsync(user);
            var removeRoles = await _userManager.RemoveFromRolesAsync(user, currrntRoles);
            var addRoles = await _userManager.AddToRoleAsync(user, roleName);

            return removeRoles.Succeeded;

        }
    }
}
