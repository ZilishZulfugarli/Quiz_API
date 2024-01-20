using System;
using QuizAPI.DTOs.Questions;

namespace QuizAPI.DTOs.Quizzes
{
	public class QuizPostDbo
	{
        public string? Name { get; set; }
        public DateTime CreationDate { get; set; }
        public List<QuestionPostDbo>? Questions { get; set; }
    }
}

