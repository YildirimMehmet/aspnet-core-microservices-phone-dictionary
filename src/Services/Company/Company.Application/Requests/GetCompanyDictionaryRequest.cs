using Company.Application.Responses;
using MediatR;
using PhoneDirectory.Shared.Models;

namespace Company.Application.Requests;

public class GetCompanyDictionaryRequest : IRequest<BaseResponseDto<IEnumerable<CompanyDictionaryDto>>>
{
}