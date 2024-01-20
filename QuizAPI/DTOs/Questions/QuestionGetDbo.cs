using System;
using QuizAPI.DTOs.Options;

namespace QuizAPI.DTOs.Questions
{
	public class QuestionGetDbo
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public	decimal Points { get; set; }
		public List<OptionGetDbo>? Options { get; set; }
	}
}

