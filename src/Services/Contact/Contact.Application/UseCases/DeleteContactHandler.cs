using Contact.Application.Repositories;
using Contact.Application.Requests;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Contact.Application.UseCases;

public class DeleteContactHandler : IRequestHandler<DeleteContactRequest>
{
    private readonly IContactRepository _contactRepository;
    private readonly ILogger<DeleteContactHandler> _logger;

    public DeleteContactHandler(IContactRepository contactRepository, ILogger<DeleteContactHandler> logger)
    {
        _contactRepository = contactRepository;
        _logger = logger;
    }

    public async Task Handle(DeleteContactRequest request, CancellationToken cancellationToken)
    {
        await _contactRepository.DeleteAsync(request.Id);
    }
}