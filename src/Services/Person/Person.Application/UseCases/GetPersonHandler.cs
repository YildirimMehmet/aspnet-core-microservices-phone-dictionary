using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Person.Application.Repositories;
using Person.Application.Requests;
using Person.Application.Responses;
using PhoneDirectory.Shared.Models;

namespace Person.Application.UseCases;

public class GetPersonHandler : IRequestHandler<GetPersonRequest, BaseResponseDto<PersonDto>>
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetPersonHandler> _logger;

    public GetPersonHandler(IPersonRepository personRepository, IMapper mapper, ILogger<GetPersonHandler> logger)
    {
        _personRepository = personRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<BaseResponseDto<PersonDto>> Handle(GetPersonRequest request, CancellationToken cancellationToken)
    {
        var response = new BaseResponseDto<PersonDto>();

        var result = await _personRepository.GetAsync(request.Id);
        response.Data = _mapper.Map<PersonDto>(result);

        return await Task.FromResult(response);
    }
}