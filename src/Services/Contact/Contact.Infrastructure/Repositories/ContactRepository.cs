using Contact.Application.Repositories;
using Microsoft.EntityFrameworkCore;
using PhoneDirectory.EntityFramework.Repositories;

namespace Contact.Infrastructure.Repositories;

public class ContactRepository : GenericRepository<Domain.Entities.Contact>, IContactRepository
{
    public ContactRepository(DbContext context) : base(context)
    {
    }
}