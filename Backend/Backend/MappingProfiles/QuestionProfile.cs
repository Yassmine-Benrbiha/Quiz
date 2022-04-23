using AutoMapper;
using QuestionModel = API.ViewModels.QuestionVM;
using QuestionDto = Components.DTO.QuestionDTO;


namespace CED.Alpha.API.MappingProfiles
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<QuestionDto, QuestionModel>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(dto => dto.QueId))
                .ForMember(vm => vm.Text, opt => opt.MapFrom(dto => dto.QueText))
                .ForMember(vm => vm.Type, opt => opt.MapFrom(dto => dto.QueType));

            CreateMap<QuestionModel, QuestionDto>()
               .ForMember(dto => dto.QueId, opt => opt.MapFrom(vm => vm.Id))
               .ForMember(dto => dto.QueText, opt => opt.MapFrom(vm => vm.Text))
               .ForMember(dto => dto.QueType, opt => opt.MapFrom(vm => vm.Type));
        }
    }
}