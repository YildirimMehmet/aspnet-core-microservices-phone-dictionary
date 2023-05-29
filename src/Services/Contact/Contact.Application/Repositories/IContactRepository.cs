using PhoneDirectory.Shared.Repositories;

namespace Contact.Application.Repositories;

public interface IContactRepository : IRepository<Domain.Entities.Contact>
{
}