using MediatR;
using Person.Application.Responses;
using PhoneDirectory.Shared.Models;

namespace Person.Application.Requests;

public class GetPersonRequest : IRequest<BaseResponseDto<PersonDto>>
{
    public Guid Id { get; set; }
}