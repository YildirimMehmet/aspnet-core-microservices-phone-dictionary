using AutoMapper;
using Report.Application.Responses;

namespace Report.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Domain.Entities.LocationReport, LocationReportDto>();
        CreateMap<Domain.Entities.LocationReport, LocationReportsDto>();
    }
}