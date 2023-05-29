using Contact.Application.Responses;
using MediatR;
using PhoneDirectory.Shared.Models;

namespace Contact.Application.Requests;

public class GetPersonContactsRequest : IRequest<BaseResponseDto<IEnumerable<ContactsDto>>>
{
    public GetPersonContactsRequest(Guid personId)
    {
        PersonId = personId;
    }

    public Guid PersonId { get; set; }
}