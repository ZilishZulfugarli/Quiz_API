﻿using System;
namespace QuizAPI.Entities
{
	public class Quiz
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public DateTime CreationDate { get; set; }

		public List<Question>? questions { get; set; }
	}
}

