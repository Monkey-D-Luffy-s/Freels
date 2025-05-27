using Freels.data;
using Freels.Modals;
using Freels.Modals.DTO;
using Freels.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Freels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HallController : ControllerBase
    {
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly UserManager<IdentityUser> userManager;
        private readonly AppDbContext appDbContext;
        public HallController(IJwtTokenGenerator _jwtTokenGenerator, AppDbContext _appDbContext, UserManager<IdentityUser> _userManager)
        {
            jwtTokenGenerator = _jwtTokenGenerator;
            appDbContext = _appDbContext;
            userManager = _userManager;

        }
        [HttpGet]
        [Route("Ping")]
        public IActionResult Ping()
        {
            return Ok("Success");
        }

        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> Register([FromBody] RegisterUser registerUser)
        {
            if (registerUser != null)
            {
                var identityUser = new IdentityUser
                {
                    UserName = registerUser.Email,
                    Email = registerUser.Email,
                };

                var identityResult = await userManager.CreateAsync(identityUser, registerUser.Password);
                if (identityResult.Succeeded)
                {
                    if (registerUser.Roles != null && registerUser.Roles.Any())
                    {
                        var identityRoles = await userManager.AddToRoleAsync(identityUser, registerUser.Roles[0]);
                        if (identityRoles.Succeeded)
                        {
                            return Ok("Registerd SuccessFully");
                        }
                    }
                }
                return BadRequest("Somthing went Wrong");
            }

            return BadRequest("data received null");
            
        }

        [HttpPost]
        [Route("LoginUser")]
        public async Task<IActionResult> Login([FromBody] LoginUser loginUser)
        {
            if(loginUser != null)
            {
                var checkUser = await userManager.FindByEmailAsync(loginUser.Email);
                if (checkUser != null) 
                {
                    var checkPass = await userManager.CheckPasswordAsync(checkUser, loginUser.Password);
                    if (checkPass)
                    {
                        var Roles = await userManager.GetRolesAsync(checkUser);
                        if(Roles != null && Roles.Any())
                        {
                            var JwtToken = jwtTokenGenerator.GenerateToken(checkUser, Roles.ToArray());
                            LoginResponse loginResponse = new LoginResponse
                            {
                                jwtToken = JwtToken,
                            };
                            return Ok(loginResponse);
                        }
                    }
                }
            }
            return BadRequest("Login Failed");
        }
    }

}
