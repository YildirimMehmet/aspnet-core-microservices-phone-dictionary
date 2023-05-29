using Contact.Application.Requests;
using Contact.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Contact.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ContactsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateContactAsync([FromBody] CreateContactRequest request)
    {
        var response = await _mediator.Send(request);
        return Created("", response.Data);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContactAsync(Guid id)
    {
        await _mediator.Send(new DeleteContactRequest() {Id = id});
        return Ok();
    }

    [HttpGet("person/{personId}")]
    public async Task<ActionResult<IEnumerable<ContactsDto>>> GetPersonContactsAsync(Guid personId)
    {
        var response = await _mediator.Send(new GetPersonContactsRequest(personId));
        return Ok(response.Data);
    }
}