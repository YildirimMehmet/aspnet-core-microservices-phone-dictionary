using PhoneDirectory.Shared.Entities;

namespace Person.Domain.Entities;

public class Person : EntityBase
{
    public Person(string firstName, string lastName, Guid companyId)
    {
        ArgumentException.ThrowIfNullOrEmpty(firstName);
        ArgumentException.ThrowIfNullOrEmpty(lastName);
        if (companyId == Guid.Empty) throw new ArgumentNullException(nameof(companyId));

        FirstName = firstName;
        LastName = lastName;
        CompanyId = companyId;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Guid CompanyId { get; private set; }
}