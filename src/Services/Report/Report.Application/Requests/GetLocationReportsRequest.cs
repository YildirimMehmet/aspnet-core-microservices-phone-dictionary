using MediatR;
using PhoneDirectory.Shared.Models;
using PhoneDirectory.Shared.Paginations;
using Report.Application.Responses;

namespace Report.Application.Requests;

public class GetLocationReportsRequest : PaginationFilter, IRequest<BaseResponseDto<PagedResponseDto<LocationReportsDto>>>
{
}