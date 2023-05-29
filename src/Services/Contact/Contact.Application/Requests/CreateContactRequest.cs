using Contact.Domain.Enums;
using MediatR;
using PhoneDirectory.Shared.Models;

namespace Contact.Application.Requests;

public class CreateContactRequest : IRequest<BaseResponseDto<Guid>>
{
    public ContactType Type { get; set; }
    public string Value { get; set; }
    public Guid PersonId { get; set; }
}