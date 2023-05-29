using Contact.Application.Responses;
using MediatR;
using PhoneDirectory.Shared.Models;

namespace Contact.Application.Requests;

public class GetLocationInfoRequest : IRequest<BaseResponseDto<LocationInfoDto>>
{
    public string Location { get; set; }
}