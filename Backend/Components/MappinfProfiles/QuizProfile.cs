using AutoMapper;
using QuizModel = Data.Models.Quiz;
using QuizDto = Components.DTO.QuizDTO;
using System.Linq;

namespace CED.Alpha.Components.MappinfProfiles
{
    public class QuizProfile : Profile
    {
        public QuizProfile() : base()
        {

            CreateMap<QuizModel, QuizDto>()
                .ForMember(dto => dto.Questions, opt => opt.MapFrom(m => m.QuizQuestions.Select(que => que.Que)));

            CreateMap<QuizDto, QuizModel>();
                
        }
    }
}