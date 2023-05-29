using MediatR;

namespace Person.Application.Requests;

public class DeletePersonRequest : IRequest
{
    public Guid Id { get; set; }
}