using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using PhoneDirectory.Shared.Models;
using Report.Application.Repositories;
using Report.Application.Requests;
using Report.Application.Responses;

namespace Report.Application.UseCases;

public class GetLocationReportsHandler : IRequestHandler<GetLocationReportsRequest, BaseResponseDto<PagedResponseDto<LocationReportsDto>>>
{
    private readonly ILocationReportRepository _locationReportRepository;
    private readonly ILogger<GetLocationReportsHandler> _logger;
    private readonly IMapper _mapper;

    public GetLocationReportsHandler(ILocationReportRepository locationReportRepository, ILogger<GetLocationReportsHandler> logger, IMapper mapper)
    {
        _locationReportRepository = locationReportRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<BaseResponseDto<PagedResponseDto<LocationReportsDto>>> Handle(GetLocationReportsRequest request, CancellationToken cancellationToken)
    {
        var response = new BaseResponseDto<PagedResponseDto<LocationReportsDto>>();
        var query = _locationReportRepository.GetAll();

        int totalItems = query.Count();
        query = query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize);

        var result = query.ToList();
        response.Data = new PagedResponseDto<LocationReportsDto>(
            _mapper.Map<IEnumerable<LocationReportsDto>>(result),
            request.PageNumber,
            request.PageSize,
            totalItems
        );

        return await Task.FromResult(response);
    }
}