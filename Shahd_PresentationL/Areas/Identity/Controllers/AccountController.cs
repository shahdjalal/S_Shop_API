using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Shahd_BusniessLL.Services.Interfaces;
using Shahd_DataAccessL.DTO.Requests;
using Shahd_DataAccessL.DTO.Responses;
namespace Shahd_PresentationL.Areas.Identity.Controllers
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Identity")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<UserResponse>> Register(RegisterRequest registerRequest, HttpRequest Request)
        {
            var result = await _authenticationService.RegisterAsync(registerRequest,  Request);
            return Ok(result);

        }
        [HttpPost("Login")]
        public async Task<ActionResult<UserResponse>> Login(LoginRequest loginRequest)
        {
            var result = await _authenticationService.LoginAsync(loginRequest);
            return Ok(result);

        }

        [HttpGet("confirmEmail")]
        public async Task<ActionResult<string>> confirmEmail([FromQuery]string token , [FromQuery] string userId)
        {
            var result = await _authenticationService.confirmEmail(token , userId);
            return Ok(result);

        }

        [HttpPost("forgotPassword")]

        public async Task<ActionResult<string>> forgotPassword([FromBody] ForgotPasswordRequest request)
        {
            var result = await _authenticationService.ForgotPassword(request);
            return Ok(result);

        }

        [HttpPatch("Reset-Password")]

        public async Task<ActionResult<string>> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var result = await _authenticationService.ResetPassword(request);
            return Ok(result);

        }

    }
} 
