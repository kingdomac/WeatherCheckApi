using IdentityServer.DTO;
using IdentityServer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityServerUser> _userManager;

        public AccountController(UserManager<IdentityServerUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userDb = await _userManager.FindByEmailAsync(user.Email);

            if (userDb is not null) return BadRequest("User already exist");

            var identityUser = new IdentityServerUser
            {
                UserName = user.Email,
                Email = user.Email

            };

            var result = await _userManager.CreateAsync(identityUser, user.Password);

            if (result.Succeeded)
            {
                //await _userManager.AddClaimAsync(identityUser, new Claim("scope", "api1"));
                return Ok("Regisration success");
            }

            return BadRequest(result.Errors);

        }
    }
}
