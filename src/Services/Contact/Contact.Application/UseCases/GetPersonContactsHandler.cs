using AutoMapper;
using Contact.Application.Repositories;
using Contact.Application.Requests;
using Contact.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using PhoneDirectory.Shared.Models;

namespace Contact.Application.UseCases;

public class GetPersonContactsHandler : IRequestHandler<GetPersonContactsRequest, BaseResponseDto<IEnumerable<ContactsDto>>>
{
    private readonly IContactRepository _contactRepository;
    private readonly ILogger<GetPersonContactsHandler> _logger;
    private readonly IMapper _mapper;

    public GetPersonContactsHandler(IContactRepository contactRepository, ILogger<GetPersonContactsHandler> logger, IMapper mapper)
    {
        _contactRepository = contactRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public Task<BaseResponseDto<IEnumerable<ContactsDto>>> Handle(GetPersonContactsRequest request, CancellationToken cancellationToken)
    {
        var response = new BaseResponseDto<IEnumerable<ContactsDto>>();
        var result = _contactRepository.GetAll().Where(i => i.PersonId == request.PersonId).ToList();

        response.Data = _mapper.Map<IEnumerable<ContactsDto>>(result);
        
        return Task.FromResult(response);
    }
}