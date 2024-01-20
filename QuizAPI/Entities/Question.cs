using System;
namespace QuizAPI.Entities
{
	public class Question
	{
		public int Id { get; set; }
		public string? QuestionName { get; set; }
		public decimal Points { get; set; }
		public int QuizId { get; set; }

		public Quiz? quiz { get; set; }
		public List<Option>? options { get; set; }
	}
}

