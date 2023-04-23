using AutoMapper;
using Keyify.Infrastructure.DTOs.ChordDefinition;
using Keyify.Infrastructure.Models.ChordDefinition;
using Keyify.MusicTheory.Enums;
using System.Linq;

namespace Keyify.Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ChordDefinitionInsertRequestDto, ChordDefinitionInsertRequest>()
                .ForMember(dest => dest.Intervals, opt => opt.MapFrom(src => src.Intervals.Select(i => (Interval)i)));
        }
    }
}
