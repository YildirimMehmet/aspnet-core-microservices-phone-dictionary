using PhoneDirectory.Shared.Repositories;

namespace Person.Application.Repositories;

public interface IPersonRepository : IRepository<Domain.Entities.Person>
{
}