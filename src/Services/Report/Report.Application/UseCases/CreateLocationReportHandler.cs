using Contact.Shared.Events;
using Contact.Shared.Models;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using PhoneDirectory.Shared.Models;
using Report.Application.Repositories;
using Report.Application.Requests;
using Report.Domain.Entities;
using Report.Domain.Enums;

namespace Report.Application.UseCases;

public class CreateLocationReportHandler : IRequestHandler<CreateLocationReportRequest, BaseResponseDto<Guid>>
{
    private readonly ILocationReportRepository _locationReportRepository;
    private readonly ILogger<CreateLocationReportHandler> _logger;
    private readonly IBusControl _busControl;

    public CreateLocationReportHandler(ILocationReportRepository locationReportRepository, ILogger<CreateLocationReportHandler> logger, IBusControl busControl)
    {
        _locationReportRepository = locationReportRepository;
        _logger = logger;
        _busControl = busControl;
    }

    public async Task<BaseResponseDto<Guid>> Handle(CreateLocationReportRequest request, CancellationToken cancellationToken)
    {
        var model = new LocationReport(request.Location, 0, 0, ReportStatus.Preparing);
        await _locationReportRepository.CreateAsync(model);

        //TODO: Outbox pattern should be used
        await _busControl.Publish<IGenerateLocationInfoReportEvent>(new GenerateLocationInfoReport()
        {
            Id = model.Id,
            Location = request.Location
        }, cancellationToken);

        return new BaseResponseDto<Guid>()
        {
            Data = model.Id
        };
    }
}