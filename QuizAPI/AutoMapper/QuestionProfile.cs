using System;
using AutoMapper;
using QuizAPI.DTOs.Questions;
using QuizAPI.DTOs.Quizzes;
using QuizAPI.Entities;

namespace QuizAPI.AutoMapper
{
	public class QuestionProfile : Profile
	{
		public QuestionProfile()
		{
            CreateMap<Question, QuestionPostDbo>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.QuestionName))
            .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.options));
            CreateMap<Question, QuestionGetDbo>();
            CreateMap<QuestionPutDbo, Question>();
            CreateMap<QuestionPostDbo, Question>();
            CreateMap<Question, QuestionGetDbo>()
            .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.options))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.QuestionName)); ;
        }
	}
}

