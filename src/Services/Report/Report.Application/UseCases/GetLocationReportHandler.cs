using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PhoneDirectory.Shared.Models;
using Report.Application.Repositories;
using Report.Application.Requests;
using Report.Application.Responses;

namespace Report.Application.UseCases;

public class GetLocationReportHandler : IRequestHandler<GetLocationReportRequest, BaseResponseDto<LocationReportDto>>
{
    private readonly ILocationReportRepository _locationReportRepository;
    private readonly ILogger<GetLocationReportHandler> _logger;
    private readonly IMapper _mapper;

    public GetLocationReportHandler(ILocationReportRepository locationReportRepository, ILogger<GetLocationReportHandler> logger, IMapper mapper)
    {
        _locationReportRepository = locationReportRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<BaseResponseDto<LocationReportDto>> Handle(GetLocationReportRequest request, CancellationToken cancellationToken)
    {
        var response = new BaseResponseDto<LocationReportDto>();

        var result = await _locationReportRepository.GetAsync(request.Id);
        response.Data = _mapper.Map<LocationReportDto>(result);

        return await Task.FromResult(response);
    }
}