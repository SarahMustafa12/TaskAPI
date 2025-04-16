using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using TaskAPI.DTOs.Request;
using TaskAPI.Models;
using TaskAPI.Unit_of_Work;

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            if (roleManager.Roles.IsNullOrEmpty())
            {
                await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
                await roleManager.CreateAsync(new IdentityRole("Admin"));
                await roleManager.CreateAsync(new IdentityRole("Company"));
                await roleManager.CreateAsync(new IdentityRole("Customer"));
            }


            ApplicationUser appUser = registerRequest.Adapt<ApplicationUser>();


            var result = await userManager.CreateAsync(appUser, registerRequest.Password);

            if (result.Succeeded)
            {

                await userManager.AddToRoleAsync(appUser, "Customer");
                return Created();
            }


            else
            {
                return BadRequest(result.Errors);
            }

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var appUser = await userManager.FindByEmailAsync(loginRequest.Email);

            if (appUser != null)
            {
                var result = await userManager.CheckPasswordAsync(appUser, loginRequest.Password);

                if (result)
                {
                    await signInManager.SignInAsync(appUser, loginRequest.RememberMe);

                    return NoContent();
                }
                else
                {
                    ModelStateDictionary keyValuePairs = new();
                    keyValuePairs.AddModelError("Error", "Email and Pass don't match");
                    return BadRequest(keyValuePairs);
                }
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return NoContent();
        }
    }
}
