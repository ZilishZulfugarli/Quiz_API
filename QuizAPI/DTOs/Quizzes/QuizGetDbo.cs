using System;
namespace QuizAPI.DTOs.Quizzes
{
	public class QuizGetDbo
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public DateTime CreationDate { get; set; }
	}
}

