using MediatR;
using Microsoft.Extensions.Logging;
using Person.Application.Repositories;
using Person.Application.Requests;

namespace Person.Application.UseCases;

public class DeletePersonHandler : IRequestHandler<DeletePersonRequest>
{
    private readonly IPersonRepository _personRepository;
    private readonly ILogger<DeletePersonHandler> _logger;

    public DeletePersonHandler(IPersonRepository personRepository, ILogger<DeletePersonHandler> logger)
    {
        _personRepository = personRepository;
        _logger = logger;
    }

    public async Task Handle(DeletePersonRequest request, CancellationToken cancellationToken)
    {
        await _personRepository.DeleteAsync(request.Id);
    }
}