using Shahd_DataAccessL.DTO.Responses;
using Shahd_DataAccessL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_BusniessLL.Services.Interfaces
{
    public interface IUserService
    {

        Task<List<UserDto>>  GetAllAsync();

        Task<UserDto> GetByIdAsync(string userId);
        Task<bool> BlockUserAsync(string userId, int days);

        Task<bool> IsBlockedAsync(string userId);
        Task<bool> unBlockUserAsync(string userId);
        Task<bool> changeUserRoleAsync(string userId, string roleName);

    }
}
