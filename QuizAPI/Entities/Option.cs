using System;
namespace QuizAPI.Entities
{
	public class Option
	{
		public int Id { get; set; }
		public string? OptionName { get; set; }
		public bool IsCorrect{ get; set; }
		public int QuestionId { get; set; }

		public Question? question { get; set; }
	}
}

