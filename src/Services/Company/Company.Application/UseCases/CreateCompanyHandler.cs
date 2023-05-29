using Company.Application.Repositories;
using Company.Application.Requests;
using MediatR;
using Microsoft.Extensions.Logging;
using PhoneDirectory.Shared.Models;

namespace Company.Application.UseCases;

public class CreateCompanyHandler : IRequestHandler<CreateCompanyRequest, BaseResponseDto<Guid>>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly ILogger<CreateCompanyHandler> _logger;

    public CreateCompanyHandler(ICompanyRepository companyRepository, ILogger<CreateCompanyHandler> logger)
    {
        _companyRepository = companyRepository;
        _logger = logger;
    }

    public async Task<BaseResponseDto<Guid>> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
    {
        var model = new Domain.Entities.Company(request.Name, request.Title);
        await _companyRepository.CreateAsync(model);

        return new BaseResponseDto<Guid>()
        {
            Data = model.Id
        };
    }
}