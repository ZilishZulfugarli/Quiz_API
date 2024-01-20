using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizAPI.DTOs.Account;
using QuizAPI.Entities;
using QuizAPI.Services.Abstract;

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        // POST: api/Account
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDbo dbo)
        {
            var user = new AppUser
            {
                Name = dbo.FirstName,
                Surname = dbo.LastName,
                UserName = dbo.UserName,
                Email = dbo.Email,
            };

            var result = await _userManager.CreateAsync(user, dbo.Password);
            if (!result.Succeeded) return BadRequest();

            return Ok();
        }

        // PUT: api/Account/5
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDbo dbo, [FromServices] IJwtTokenService jwtTokenService)
        {
            var user = await _userManager.FindByNameAsync(dbo.UserName);
            if (user is null) return NotFound();

            var pass = await _userManager.CheckPasswordAsync(user, dbo.Password);
            if (pass is false) return NotFound();

            var role = (await _userManager.GetRolesAsync(user)).ToList();

            var token = jwtTokenService.GenerateToken(user?.Name, user?.Surname, user?.UserName, role);

            return Ok(token);

        }
    }
}
