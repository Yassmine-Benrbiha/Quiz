using AutoMapper;
using QuizViewModel = API.ViewModels.QuizVM;
using QuizDto = Components.DTO.QuizDTO;


namespace CED.Alpha.API.MappingProfiles
{
    public class QuizProfile : Profile
    {
        public QuizProfile()
        {
            CreateMap<QuizDto, QuizViewModel>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(dto => dto.QuiId))
                .ForMember(vm => vm.Title, opt => opt.MapFrom(dto => dto.QuiTitle))
                .ForMember(vm => vm.CreatedBy, opt => opt.MapFrom(dto => dto.QuiCreatedBy));

            CreateMap<QuizViewModel, QuizDto>()
               .ForMember(dto => dto.QuiId, opt => opt.MapFrom(vm => vm.Id))
               .ForMember(dto => dto.QuiTitle, opt => opt.MapFrom(vm => vm.Title))
               .ForMember(dto => dto.QuiCreatedBy, opt => opt.MapFrom(dto => dto.CreatedBy));
        }
    }
}