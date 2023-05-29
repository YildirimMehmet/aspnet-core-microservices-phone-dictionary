using Contact.Application.Requests;
using Contact.Shared.Events;
using MassTransit;
using MediatR;
using Report.Shared.Events;
using Report.Shared.Models;

namespace Contact.API.Consumers;

public class GenerateLocationInfoReportConsumer : IConsumer<IGenerateLocationInfoReportEvent>
{
    private readonly IMediator _mediator;
    private readonly IBusControl _busControl;

    public GenerateLocationInfoReportConsumer(IMediator mediator, IBusControl busControl)
    {
        _mediator = mediator;
        _busControl = busControl;
    }

    public async Task Consume(ConsumeContext<IGenerateLocationInfoReportEvent> context)
    {
        var message = context.Message;
        var result = await _mediator.Send(new GetLocationInfoRequest()
        {
            Location = message.Location
        });
        
        await _busControl.Publish<ICompleteLocationReportEvent>(new CompleteLocationReport()
        {
            Id = message.Id,
            NumberOfPeople = result.Data.NumberOfPersons,
            NumberOfPhoneNumbers = result.Data.NumberOfPhoneNumbers
        });
    }
}