using MediatR;
using PhoneDirectory.Shared.Models;

namespace Company.Application.Requests;

public class CreateCompanyRequest : IRequest<BaseResponseDto<Guid>>
{
    public string Name { get; set; }
    public string Title { get; set; }
}