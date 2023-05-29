using Microsoft.EntityFrameworkCore;
using Person.Application.Repositories;
using PhoneDirectory.EntityFramework.Repositories;

namespace Person.Infrastructure.Repositories;

public class PersonRepository : GenericRepository<Domain.Entities.Person>, IPersonRepository
{
    public PersonRepository(DbContext context) : base(context)
    {
    }
}