using AutoMapper;
using OptionModel = Data.Models.Option;
using OptionDto = Components.DTO.OptionDTO;
using System.Linq;

namespace CED.Alpha.Components.MappinfProfiles
{
    public class OptionProfile : Profile
    {
        public OptionProfile() : base()
        {
            CreateMap<OptionModel, OptionDto>();
            CreateMap<OptionDto, OptionModel>();
        }
    }
}