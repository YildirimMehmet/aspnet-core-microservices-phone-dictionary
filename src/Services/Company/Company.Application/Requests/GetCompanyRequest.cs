using Company.Application.Responses;
using MediatR;
using PhoneDirectory.Shared.Models;

namespace Company.Application.Requests;

public class GetCompanyRequest : IRequest<BaseResponseDto<CompanyDto>>
{
    public Guid Id { get; set; }
}