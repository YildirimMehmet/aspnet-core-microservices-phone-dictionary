using Company.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using PhoneDirectory.EntityFramework.Repositories;

namespace Company.Infrastructure.Repositories;

public class CompanyRepository : GenericRepository<Domain.Entities.Company>, ICompanyRepository
{
    public CompanyRepository(DbContext context) : base(context)
    {
    }
}