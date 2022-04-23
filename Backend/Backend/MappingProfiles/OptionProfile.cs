using AutoMapper;
using OptionViewModel = API.ViewModels.OptionVM;
using OptionDto = Components.DTO.OptionDTO;


namespace CED.Alpha.API.MappingProfiles
{
    public class OptionProfile : Profile
    {
        public OptionProfile()
        {
            CreateMap<OptionDto, OptionViewModel>()
                .ForMember(vm => vm.Id, opt => opt.MapFrom(dto => dto.OptId))
                 .ForMember(vm => vm.Text, opt => opt.MapFrom(dto => dto.OptText))
                .ForMember(vm => vm.Value, opt => opt.MapFrom(dto => dto.OptValue));

            CreateMap<OptionViewModel, OptionDto>()
               .ForMember(dto => dto.OptId, opt => opt.MapFrom(vm => vm.Id))
                .ForMember(vm => vm.OptText, opt => opt.MapFrom(dto => dto.Text))
               .ForMember(dto => dto.OptValue, opt => opt.MapFrom(vm => vm.Value));
        }
    }
}