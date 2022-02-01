using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using TestProjectApp.Models.Services;
using TestProjectApp.Models.ViewModels;
using TestProjectApp.Models;

namespace TestProjectApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtService _jwtService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public JwtController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IJwtService jwtService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtService = jwtService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginViewModel login)
        {

            var result = await _signInManager.PasswordSignInAsync(login.userName, login.password, false, true);

            if (!result.Succeeded)
            {
                return Unauthorized();
            }
            ApplicationUser user = await _userManager.FindByNameAsync(login.userName);
            IList<string> userRoles = await _userManager.GetRolesAsync(user);

            string jwtToken = _jwtService.GenerateJwtToken(user, userRoles, User.Claims);

            return Ok(jwtToken);

        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult TestJwtToken()
        {
            return Ok("It works");
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegViewModel userReg)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = userReg.UserName,
                    Email = userReg.Email
                };
                IdentityResult result = await _userManager.CreateAsync(user, userReg.Password);
                IdentityResult role = await _userManager.AddToRoleAsync(user, "User");

                if (result.Succeeded)
                {
                    return Ok("Created");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
            }
            return BadRequest(ModelState);
        }
    }
}
