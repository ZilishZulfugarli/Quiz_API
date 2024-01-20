using System;
namespace QuizAPI.Services.Abstract
{
	public interface IJwtTokenService
	{
		public string GenerateToken(string name, string surname, string userName, List<string> role);
	}
}

