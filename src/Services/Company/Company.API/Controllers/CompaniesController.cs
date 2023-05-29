using Company.Application.Requests;
using Company.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneDirectory.Shared.Models;

namespace Company.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompaniesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("dictionary")]
    public async Task<ActionResult<IEnumerable<CompanyDictionaryDto>>> GetCompanyDictionaryAsync()
    {
        BaseResponseDto<IEnumerable<CompanyDictionaryDto>> response = await _mediator.Send(new GetCompanyDictionaryRequest());
        return Ok(response.Data);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCompanyAsync([FromBody] CreateCompanyRequest request)
    {
        var response = await _mediator.Send(request);
        return Created("", response.Data);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompanyAsync(Guid id)
    {
        await _mediator.Send(new DeleteCompanyRequest {Id = id});
        return Ok();
    }
}