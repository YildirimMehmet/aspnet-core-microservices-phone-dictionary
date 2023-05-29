using Company.Application.Repositories;
using Company.Application.Requests;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Company.Application.UseCases;

public class DeleteCompanyHandler : IRequestHandler<DeleteCompanyRequest>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly ILogger<DeleteCompanyHandler> _logger;

    public DeleteCompanyHandler(ICompanyRepository companyRepository, ILogger<DeleteCompanyHandler> logger)
    {
        _companyRepository = companyRepository;
        _logger = logger;
    }

    public async Task Handle(DeleteCompanyRequest request, CancellationToken cancellationToken)
    {
        await _companyRepository.DeleteAsync(request.Id);
    }
}