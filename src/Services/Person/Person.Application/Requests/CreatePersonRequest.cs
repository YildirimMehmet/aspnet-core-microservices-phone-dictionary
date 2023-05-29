using MediatR;
using PhoneDirectory.Shared.Models;

namespace Person.Application.Requests;

public class CreatePersonRequest : IRequest<BaseResponseDto<Guid>>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid CompanyId { get; set; }
}