using AutoMapper;
using Contact.Application.Responses;

namespace Contact.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Domain.Entities.Contact, ContactDto>();
        CreateMap<Domain.Entities.Contact, ContactsDto>();
    }
}