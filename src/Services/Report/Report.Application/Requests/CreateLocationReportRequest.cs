using MediatR;
using PhoneDirectory.Shared.Models;

namespace Report.Application.Requests;

public class CreateLocationReportRequest : IRequest<BaseResponseDto<Guid>>
{
    public string Location { get; set; }
}