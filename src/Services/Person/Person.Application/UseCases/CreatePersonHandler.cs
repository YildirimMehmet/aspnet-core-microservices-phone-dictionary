using MediatR;
using Microsoft.Extensions.Logging;
using Person.Application.Repositories;
using Person.Application.Requests;
using PhoneDirectory.Shared.Models;

namespace Person.Application.UseCases;

public class CreatePersonHandler : IRequestHandler<CreatePersonRequest, BaseResponseDto<Guid>>
{
    private readonly IPersonRepository _personRepository;
    private readonly ILogger<CreatePersonHandler> _logger;

    public CreatePersonHandler(IPersonRepository personRepository, ILogger<CreatePersonHandler> logger)
    {
        _personRepository = personRepository;
        _logger = logger;
    }

    public async Task<BaseResponseDto<Guid>> Handle(CreatePersonRequest request, CancellationToken cancellationToken)
    {
        var model = new Domain.Entities.Person(request.FirstName, request.LastName, request.CompanyId);
        await _personRepository.CreateAsync(
            model
        );

        return new BaseResponseDto<Guid>()
        {
            Data = model.Id
        };
    }
}