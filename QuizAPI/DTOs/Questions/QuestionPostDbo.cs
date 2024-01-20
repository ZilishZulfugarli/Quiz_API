using System;
using QuizAPI.DTOs.Options;

namespace QuizAPI.DTOs.Questions
{
	public class QuestionPostDbo
	{
		public string? Name { get; set; }
		public decimal Points { get; set; }
		public List<OptionPostDbo>? Options { get; set; }
	}
}

