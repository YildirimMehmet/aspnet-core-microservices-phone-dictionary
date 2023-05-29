using MediatR;
using Person.Application.Responses;
using PhoneDirectory.Shared.Models;
using PhoneDirectory.Shared.Paginations;

namespace Person.Application.Requests;

public class GetPersonsRequest : PaginationFilter, IRequest<BaseResponseDto<PagedResponseDto<PersonsDto>>>
{
}