using Autentica.Models;
using AutoMapper;

namespace Autentica.Mappers
{
    public class CsvCoordinateMapper : Profile
    {
        public CsvCoordinateMapper()
        {
            CreateMap<CsvDataModel, PlacesAndCoordinatesModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.NOSAUKUMS.Replace("#", "")))
                .ForMember(dest => dest.NCoordinate, opt => opt.MapFrom(src => float.Parse(src.DD_N.Replace("#", ""))))
                .ForMember(dest => dest.ECoordinate, opt => opt.MapFrom(src => float.Parse(src.DD_E.Replace("#", ""))));
        }
    }
}
