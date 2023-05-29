using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Person.Application.Repositories;
using Person.Application.Requests;
using Person.Application.Responses;
using PhoneDirectory.Shared.Models;

namespace Person.Application.UseCases;

public class GetPersonsHandler : IRequestHandler<GetPersonsRequest, BaseResponseDto<PagedResponseDto<PersonsDto>>>
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetPersonsHandler> _logger;

    public GetPersonsHandler(IMapper mapper, IPersonRepository personRepository, ILogger<GetPersonsHandler> logger)
    {
        _mapper = mapper;
        _personRepository = personRepository;
        _logger = logger;
    }

    public async Task<BaseResponseDto<PagedResponseDto<PersonsDto>>> Handle(GetPersonsRequest request, CancellationToken cancellationToken)
    {
        var response = new BaseResponseDto<PagedResponseDto<PersonsDto>>();

        var query = _personRepository.GetAll();

        int totalItems = query.Count();
        query = query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize);

        var result = query.ToList();
        response.Data = new PagedResponseDto<PersonsDto>(
            _mapper.Map<IEnumerable<PersonsDto>>(result),
            request.PageNumber,
            request.PageSize,
            totalItems
        );

        return await Task.FromResult(response);
    }
}