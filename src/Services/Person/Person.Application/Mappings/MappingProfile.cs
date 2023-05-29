using AutoMapper;
using Person.Application.Responses;

namespace Person.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Domain.Entities.Person, PersonDto>();
        CreateMap<Domain.Entities.Person, PersonsDto>();
    }
}