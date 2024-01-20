using System;
using QuizAPI.DTOs.Questions;

namespace QuizAPI.DTOs.Quizzes
{
	public class QuizDetailedGetDbo
	{
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreationDate { get; set; }
        public List<QuestionGetDbo>? Questions { get; set; }
    }
}

