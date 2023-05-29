using Microsoft.EntityFrameworkCore;
using PhoneDirectory.EntityFramework.Repositories;
using Report.Application.Repositories;
using Report.Domain.Entities;

namespace Report.Infrastructure.Repositories;

public class LocationReportRepository : GenericRepository<LocationReport>, ILocationReportRepository
{
    public LocationReportRepository(DbContext context) : base(context)
    {
    }
}