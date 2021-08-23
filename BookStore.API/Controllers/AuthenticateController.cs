using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BookStore.Business.DataTransferObjects.UserIdentityDTO;
using BookStore.Entities;
using BookStore.Entities.UserIdentityEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticateController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Bearer")["SecurityKey"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration.GetSection("Bearer")["Issuer"],
                    audience: _configuration.GetSection("Bearer")["Audience"],
                    expires: DateTime.Now.AddHours(8),                    
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (UsernameControlAsync(model).Result == null)
                return StatusCode(StatusCodes.Status403Forbidden, new Response { Status = "Error", Message = Messages.UserExist });

            var user = AddUserAsync(model).Result;
            if (user != null)
            {
                await userManager.AddToRoleAsync(user, UserRoles.User);
                return Ok(new Response { Status = "Success", Message = Messages.CreationSuccess });
            }
            return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = Messages.CreationFailed });
        }

        [HttpPost]
        [Route("register-admin")]
        //[Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> RegisterAdmin(RegisterModel model)
        {
            if (UsernameControlAsync(model).Result == null)
                return StatusCode(StatusCodes.Status403Forbidden, new Response { Status = "Error", Message = Messages.UserExist});
            
            var admin = AddUserAsync(model).Result;
            if (admin != null)
            {
                await userManager.AddToRoleAsync(admin, UserRoles.Admin);
                return Ok(new Response { Status = "Success", Message = Messages.CreationSuccess });
            }
            return StatusCode(StatusCodes.Status404NotFound, new Response { Status = "Error", Message = Messages.CreationFailed });
     
        }
        private async Task<dynamic> UsernameControlAsync(RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return null;
            return true;
        }
        private async Task<dynamic> AddUserAsync(RegisterModel model)
        {
            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return null;

            return user;
        }

    }
}
