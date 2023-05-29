using PhoneDirectory.Shared.Entities;

namespace Company.Domain.Entities;

public class Company : EntityBase
{
    public Company(string name, string title)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        ArgumentException.ThrowIfNullOrEmpty(title);

        Name = name;
        Title = title;
    }

    public string Name { get; private set; }
    public string Title { get; private set; }
}