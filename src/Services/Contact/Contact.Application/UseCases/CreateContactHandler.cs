using Contact.Application.Repositories;
using Contact.Application.Requests;
using Contact.Domain.Enums;
using Contact.Domain.ValueObjects;
using MediatR;
using Microsoft.Extensions.Logging;
using PhoneDirectory.Shared.Models;

namespace Contact.Application.UseCases;

public class CreateContactHandler : IRequestHandler<CreateContactRequest, BaseResponseDto<Guid>>
{
    private readonly IContactRepository _contactRepository;
    private readonly ILogger<CreateContactHandler> _logger;

    public CreateContactHandler(IContactRepository contactRepository, ILogger<CreateContactHandler> logger)
    {
        _contactRepository = contactRepository;
        _logger = logger;
    }

    public async Task<BaseResponseDto<Guid>> Handle(CreateContactRequest request, CancellationToken cancellationToken)
    {
        var model = request.Type switch
        {
            ContactType.EmailAddress => new Domain.Entities.Contact(new EmailAddress(request.Value), request.PersonId),
            ContactType.Location => new Domain.Entities.Contact(new Location(request.Value), request.PersonId),
            ContactType.PhoneNumber => new Domain.Entities.Contact(new PhoneNumber(request.Value), request.PersonId)
        };

        await _contactRepository.CreateAsync(model);

        return new BaseResponseDto<Guid>()
        {
            Data = model.Id
        };
    }
}