using System;
using AutoMapper;
using QuizAPI.DTOs.Options;
using QuizAPI.DTOs.Questions;
using QuizAPI.Entities;

namespace QuizAPI.AutoMapper
{
	public class OptionProfile : Profile
	{
		public OptionProfile()
		{
            CreateMap<Option, OptionPostDbo>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.OptionName))
            .ForMember(dest => dest.IsCorrect, opt => opt.MapFrom(src => src.IsCorrect));
            CreateMap<Option, OptionGetDbo>();
            CreateMap<OptionPutDbo, Option>();
            CreateMap<OptionPostDbo, Option>();
            
            CreateMap<Option, OptionGetDbo>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.OptionName)); ;
        }
	}
}

