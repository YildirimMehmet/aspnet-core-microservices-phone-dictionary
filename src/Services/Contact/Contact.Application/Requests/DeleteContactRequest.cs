using MediatR;

namespace Contact.Application.Requests;

public class DeleteContactRequest : IRequest
{
    public Guid Id { get; set; }
}