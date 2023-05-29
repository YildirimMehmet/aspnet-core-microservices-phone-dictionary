using MediatR;
using Microsoft.AspNetCore.Mvc;
using Person.Application.Requests;
using Person.Application.Responses;
using PhoneDirectory.Shared.Models;
using PhoneDirectory.Shared.Paginations;

namespace Person.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PersonsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonsDto>>> GetPersonsAsync([FromQuery] PaginationFilter filter)
    {
        var response = await _mediator.Send(new GetPersonsRequest()
        {
            PageNumber = filter.PageNumber,
            PageSize = filter.PageSize
        });
        return Ok(response.Data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PersonDto>> GetPersonAsync(Guid id)
    {
        var response = await _mediator.Send(new GetPersonRequest() {Id = id});
        return Ok(response.Data);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePersonAsync([FromBody] CreatePersonRequest request)
    {
        var response = await _mediator.Send(request);
        return Created("", response.Data);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePersonAsync(Guid id)
    {
        await _mediator.Send(new DeletePersonRequest() {Id = id});
        return Ok();
    }
}