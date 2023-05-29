using MediatR;

namespace Company.Application.Requests;

public class DeleteCompanyRequest : IRequest
{
    public Guid Id { get; set; }
}