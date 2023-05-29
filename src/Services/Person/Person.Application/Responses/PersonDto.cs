namespace Person.Application.Responses;

public class PersonDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid CompanyId { get; set; }
}