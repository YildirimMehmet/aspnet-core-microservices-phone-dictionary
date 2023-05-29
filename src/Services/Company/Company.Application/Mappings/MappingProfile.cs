using AutoMapper;
using Company.Application.Responses;

namespace Company.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Domain.Entities.Company, CompanyDto>();
        CreateMap<Domain.Entities.Company, CompanyDictionaryDto>();
    }
}