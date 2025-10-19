using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shahd_BusniessLL.Services.Interfaces;
using Shahd_DataAccessL.DTO.Requests;
using Shahd_DataAccessL.DTO.Requests;
using Shahd_DataAccessL.DTO.Responses;
using Shahd_DataAccessL.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shahd_BusniessLL.Services.Classes
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailSender _emailSender;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthenticationService(UserManager<ApplicationUser> userManager ,
            IConfiguration configuration ,
            IEmailSender emailSender,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _emailSender = emailSender;
            _signInManager = signInManager;
        }

        public async Task<UserResponse> LoginAsync(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);

            if (user is null)
            {
                throw new Exception("invalid email or password");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginRequest.Password, true);
            if (result.Succeeded)
            {
                return new UserResponse
                {
                    Token = await CreateTokenAsync(user)
                };
            }else if (result.IsLockedOut)
            {
                throw new Exception("account is locked");
            }
            else if (result.IsNotAllowed)
            {
                throw new Exception("please confirm your email");
            }
            else
            {
                throw new Exception("invalid email or password");
            }

        }

        public async Task<string> confirmEmail(string token ,string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if(user is null)
            {
                throw new Exception("user not found");
            }



            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                return "email confirmed successeded";
            }

            return "email confirmed failed";

        }
        public async Task<UserResponse> RegisterAsync(RegisterRequest registerRequest, HttpRequest Request)
        {

            //manual mapping
            var user = new ApplicationUser()
            {
                FullName = registerRequest.FullName,
                UserName = registerRequest.UserName,
                Email = registerRequest.Email,
                PhoneNumber = registerRequest.PhoneNumber,

            };

            var Result = await _userManager.CreateAsync(user, registerRequest.Password);

            if (Result.Succeeded)
            {


             var token =   await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var escapeToken = Uri.EscapeDataString(token);
              
               var emailUrl = $"{Request.Scheme}://{Request.Host}/api/identity/Account/confirmEmail?token={escapeToken}&userId={user.Id}";

                await _userManager.AddToRoleAsync(user, "Customer");


          await _emailSender.SendEmailAsync(user.Email, "welcome",$"<h1> Hello {user.UserName} </h1>" + $"<a href='{emailUrl}'> confirm  </a>");



                return new UserResponse()
                {
                    Token = registerRequest.Email,
                };
            }

                else
            {
                throw new Exception($"{Result.Errors}");
            }
        }

        private async Task<string> CreateTokenAsync(ApplicationUser user)
        {
            var claims = new List<Claim>()
    {
        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        new Claim(JwtRegisteredClaimNames.Name, user.UserName),
        new Claim(ClaimTypes.NameIdentifier, user.Id), 
    };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("jwtOptions")["secretKey"]));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(15),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> ForgotPassword(ForgotPasswordRequest  request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null) throw new Exception("user not found");

            var random = new Random();
            var code = random.Next(1000, 9999).ToString();

            user.CodeResetPass = code;

            user.ResetPasswordCodeExpiry = DateTime.UtcNow.AddMinutes(15);  //صالح لمدة 15 د

            await _userManager.UpdateAsync(user);

            await _emailSender.SendEmailAsync(request.Email, "reset password", $"<p>code is {code }</p>");

            return "check your email";
                }



        public async Task<bool> ResetPassword(ResetPasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null) throw new Exception("user not found");

            if (user.CodeResetPass != request.Code) return false;

            if (user.ResetPasswordCodeExpiry < DateTime.UtcNow) return false;

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _userManager.ResetPasswordAsync(user,token,request.NewPassword);

            if (result.Succeeded)
            
               await _emailSender.SendEmailAsync(request.Email, "change password","<h1>your password is changed</h1>");

               
            
 return true;
        }


    }
    }


