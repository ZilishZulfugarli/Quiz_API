using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using QuizAPI.Services.Abstract;

namespace QuizAPI.Services.Concrete
{
	public class JwtTokenService : IJwtTokenService
	{
        private readonly IConfiguration _configuration;

        public JwtTokenService(IConfiguration configuration)
		{
			_configuration = configuration;
        }

		public string GenerateToken(string name, string surname, string userName, List<string> role)
		{
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));

			var claims = new List<Claim>()
			{
				new Claim("Name", name),
				new Claim("Surname", surname),
				new Claim("Username", userName),
			};

			claims.AddRange(role.Select(x =>
			new Claim(ClaimTypes.Role, x)));

			var token = new JwtSecurityToken(expires: DateTime.Now.AddMinutes(15),
				signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256), claims: claims);

			return new JwtSecurityTokenHandler().WriteToken(token);

		}
	}
}

