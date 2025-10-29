using AutoMapper;
using Orcamentaria.ServiceName.Domain.DTOs.Example;
using Orcamentaria.ServiceName.Domain.Models;

namespace Orcamentaria.ServiceName.Domain.Mappers
{
    public class ExampleMapper : Profile
    {
        public ExampleMapper() 
        {
            CreateMap<Example, ExampleResponseDTO>()
                .ForMember(s => s.Id, opt => opt.MapFrom(d => d.Id))
                .ForMember(s => s.Name, opt => opt.MapFrom(d => d.Name))
                .ForMember(s => s.Active, opt => opt.MapFrom(d => d.Active))
                .ForMember(s => s.OrderId, opt => opt.MapFrom(d => d.OrderId))
                .ReverseMap();
        }
    }
}
