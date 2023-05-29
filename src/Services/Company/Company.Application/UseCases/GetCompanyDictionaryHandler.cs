using AutoMapper;
using Company.Application.Repositories;
using Company.Application.Requests;
using Company.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using PhoneDirectory.Shared.Models;

namespace Company.Application.UseCases;

public class GetCompanyDictionaryHandler : IRequestHandler<GetCompanyDictionaryRequest, BaseResponseDto<IEnumerable<CompanyDictionaryDto>>>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly ILogger<GetCompanyDictionaryHandler> _logger;
    private readonly IMapper _mapper;

    public GetCompanyDictionaryHandler(ICompanyRepository companyRepository, ILogger<GetCompanyDictionaryHandler> logger, IMapper mapper)
    {
        _companyRepository = companyRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public Task<BaseResponseDto<IEnumerable<CompanyDictionaryDto>>> Handle(GetCompanyDictionaryRequest request, CancellationToken cancellationToken)
    {
        BaseResponseDto<IEnumerable<CompanyDictionaryDto>> response = new BaseResponseDto<IEnumerable<CompanyDictionaryDto>>();

        var result = _mapper.Map<IEnumerable<CompanyDictionaryDto>>(_companyRepository.GetAll().ToList());
        response.Data = result;

        return Task.FromResult(response);
    }
}