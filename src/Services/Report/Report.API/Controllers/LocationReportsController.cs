using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneDirectory.Shared.Paginations;
using Report.Application.Requests;
using Report.Application.Responses;

namespace Report.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LocationReportsController : ControllerBase
{
    private readonly IMediator _mediator;

    public LocationReportsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LocationReportsDto>>> GetLocationReportsAsync([FromQuery] PaginationFilter filter)
    {
        var response = await _mediator.Send(new GetLocationReportsRequest()
        {
            PageNumber = filter.PageNumber,
            PageSize = filter.PageSize
        });
        return Ok(response.Data);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLocationReportAsync([FromBody] CreateLocationReportRequest request)
    {
        var response = await _mediator.Send(request);
        return Created("", response.Data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LocationReportDto>> GetLocationReportAsync(Guid id)
    {
        var response = await _mediator.Send(new GetLocationReportRequest {Id = id});
        return Ok(response.Data);
    }
}