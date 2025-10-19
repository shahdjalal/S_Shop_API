using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shahd_BusniessLL.Services.Interfaces;
using Shahd_DataAccessL.DTO.Requests;

namespace Shahd_PresentationL.Areas.Admin.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Admin")]
   // [Authorize(Roles = "Admin,SuperAdmin")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("")]

        public async Task<IActionResult> GetallUsers()
        {
            var users= await _userService.GetAllAsync();

            return Ok(users);

        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetUserById([FromRoute]string id)
        {
            var user = await _userService.GetByIdAsync(id);

            return Ok(user);


        }

        [HttpPatch("block/{userId}")]
        public async Task<IActionResult> BlockUser([FromRoute] string userId, [FromBody]int days)
        {
            var result = await _userService.BlockUserAsync(userId,days);

            return Ok(result);


        }

        [HttpPatch("ubBlock/{userId}")]
        public async Task<IActionResult> unBlockUser([FromRoute] string userId)
        {
            var result = await _userService.unBlockUserAsync(userId);

            return Ok(result);


        }


        [HttpPatch("Isblock/{userId}")]
        public async Task<IActionResult>   IsBlockUser([FromRoute] string userId)
        {
            var result = await _userService.IsBlockedAsync(userId);

            return Ok(result);


        }

        [HttpPatch("changeRole/{userId}")]

        public async Task<IActionResult> ChangeRole([FromRoute]string userId,[FromBody] ChangeRoleRequest request)
        {
            var result= await _userService.changeUserRoleAsync(userId, request.RoleName);

            return Ok(new {message="role changed successfully" });
        }
    }
}
