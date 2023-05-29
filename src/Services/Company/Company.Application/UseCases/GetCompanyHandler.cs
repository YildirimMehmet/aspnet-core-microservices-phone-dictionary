using AutoMapper;
using Company.Application.Repositories;
using Company.Application.Requests;
using Company.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using PhoneDirectory.Shared.Models;

namespace Company.Application.UseCases;

public class GetCompanyHandler : IRequestHandler<GetCompanyRequest, BaseResponseDto<CompanyDto>>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<GetCompanyHandler> _logger;

    public GetCompanyHandler(ICompanyRepository companyRepository, IMapper mapper, ILogger<GetCompanyHandler> logger)
    {
        _companyRepository = companyRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<BaseResponseDto<CompanyDto>> Handle(GetCompanyRequest request, CancellationToken cancellationToken)
    {
        BaseResponseDto<CompanyDto> response = new BaseResponseDto<CompanyDto>();

        var result = await _companyRepository.GetAsync(request.Id);
        response.Data = _mapper.Map<CompanyDto>(result);

        return await Task.FromResult(response);
    }
}