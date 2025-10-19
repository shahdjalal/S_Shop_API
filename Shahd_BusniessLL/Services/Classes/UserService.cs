using Mapster;
using Microsoft.AspNetCore.Identity;
using Shahd_BusniessLL.Services.Interfaces;
using Shahd_DataAccessL.DTO.Responses;
using Shahd_DataAccessL.Models;
using Shahd_DataAccessL.Repositories.Interfaces;
using System;

namespace Shahd_BusniessLL.Services.Classes
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(IUserRepo userRepo, UserManager<ApplicationUser> userManager)
        {
            _userRepo = userRepo;
            _userManager = userManager;
        }

     

        public async Task<List<UserDto>> GetAllAsync()
        {
           var users= await _userRepo.GetAllAsync();

            var userDtos= new List<UserDto>();

            foreach (var user in users)
            {
                var role= await _userManager.GetRolesAsync(user);
                userDtos.Add(new UserDto
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    UserName = user.UserName,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    RoleName = role.FirstOrDefault()


                });
                    
            }

            return userDtos;
        }

        public async Task<UserDto> GetByIdAsync(string userId)
        {
            var user = await _userRepo.GetByIdAsync(userId);
            return user.Adapt<UserDto>();
        }


        public async Task<bool> BlockUserAsync(string userId, int days)
        {
            return await _userRepo.BlockUserAsync(userId,days);
        }

        public Task<bool> IsBlockedAsync(string userId)
        {
            return _userRepo.IsBlockedAsync(userId);
        }

        public  Task<bool> unBlockUserAsync(string userId)
        {
            return  _userRepo.unBlockUserAsync(userId);
        }

        public async Task<bool> changeUserRoleAsync(string userId, string roleName)
        {
            return await _userRepo.changeUserRoleAsync(userId, roleName);
        }
    }
}
