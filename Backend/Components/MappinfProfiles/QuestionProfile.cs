using AutoMapper;
using QuestionModel = Data.Models.Question;
using QuestionDto = Components.DTO.QuestionDTO;
using System.Linq;

namespace CED.Alpha.Components.MappinfProfiles
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile() : base()
        {
            CreateMap<QuestionModel, QuestionDto>()
                .ForMember(dto => dto.Options, opt => opt.MapFrom(m => m.QuestionOptions.Select(opt => opt.Opt)));

            CreateMap<QuestionDto, QuestionModel>();
            ;
        }
    }
}