using MediatR;
using Microsoft.Extensions.Logging;
using Report.Application.Events;
using Report.Application.Repositories;
using Report.Domain.Enums;

namespace Report.Application.UseCases;

public class CompleteLocationReportHandler : INotificationHandler<CompleteLocationReportEvent>
{
    private readonly ILocationReportRepository _locationReportRepository;
    private readonly ILogger<CompleteLocationReportHandler> _logger;

    public CompleteLocationReportHandler(ILocationReportRepository locationReportRepository, ILogger<CompleteLocationReportHandler> logger)
    {
        _locationReportRepository = locationReportRepository;
        _logger = logger;
    }

    public async Task Handle(CompleteLocationReportEvent @event, CancellationToken cancellationToken)
    {
        var locationReport = await _locationReportRepository.GetAsync(@event.Id);
        locationReport.NumberOfPeople = @event.NumberOfPeople;
        locationReport.NumberOfPhoneNumbers = @event.NumberOfPhoneNumbers;
        locationReport.Status = ReportStatus.Completed;

        await _locationReportRepository.UpdateAsync(locationReport);

        // TODO: Send notification for completed report
    }
}