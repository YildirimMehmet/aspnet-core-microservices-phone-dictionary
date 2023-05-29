using MediatR;
using PhoneDirectory.Shared.Models;
using Report.Application.Responses;

namespace Report.Application.Requests;

public class GetLocationReportRequest : IRequest<BaseResponseDto<LocationReportDto>>
{
    public Guid Id { get; set; }
}