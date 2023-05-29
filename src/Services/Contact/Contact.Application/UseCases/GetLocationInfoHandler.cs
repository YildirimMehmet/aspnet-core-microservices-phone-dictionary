using Contact.Application.Repositories;
using Contact.Application.Requests;
using Contact.Application.Responses;
using Contact.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using PhoneDirectory.Shared.Models;

namespace Contact.Application.UseCases;

public class GetLocationInfoHandler : IRequestHandler<GetLocationInfoRequest, BaseResponseDto<LocationInfoDto>>
{
    private readonly IContactRepository _contactRepository;
    private readonly ILogger<GetLocationInfoHandler> _logger;

    public GetLocationInfoHandler(IContactRepository contactRepository, ILogger<GetLocationInfoHandler> logger)
    {
        _contactRepository = contactRepository;
        _logger = logger;
    }

    public async Task<BaseResponseDto<LocationInfoDto>> Handle(GetLocationInfoRequest request, CancellationToken cancellationToken)
    {
        BaseResponseDto<LocationInfoDto> response = new BaseResponseDto<LocationInfoDto>()
        {
            Data = new LocationInfoDto()
        };

        var personIds = _contactRepository.GetAll()
            .Where(i => i.Type == ContactType.Location
                        && i.Value.Contains(request.Location))
            .Select(s => s.PersonId).ToList();

        var numberOfPerson = _contactRepository
            .GetAll().Count(i => i.Type == ContactType.PhoneNumber
                                 && personIds.Contains(i.PersonId));

        response.Data.NumberOfPersons = personIds.Count;
        response.Data.NumberOfPhoneNumbers = numberOfPerson;

        return await Task.FromResult(response);
    }
}