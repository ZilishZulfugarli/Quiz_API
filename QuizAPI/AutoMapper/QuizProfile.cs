using System;
using AutoMapper;
using QuizAPI.DTOs.Quizzes;
using QuizAPI.Entities;

namespace QuizAPI.AutoMapper
{
	public class QuizProfile : Profile
	{
		public QuizProfile()
		{
            CreateMap<Quiz, QuizPostDbo>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.questions));
            CreateMap<Quiz, QuizGetDbo>();
			CreateMap<QuizPutDbo, Quiz>();
			CreateMap<QuizPostDbo, Quiz>();
            CreateMap<Quiz, QuizDetailedGetDbo>()
            .ForMember(dest => dest.Questions, opt => opt.MapFrom(src => src.questions));
        }
	}
}

