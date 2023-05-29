using PhoneDirectory.Shared.Entities;

namespace PhoneDirectory.Shared.Repositories;

public interface IRepository<T> : IDisposable where T : EntityBase
{
    Task CreateAsync(T entity);
    Task DeleteAsync(Guid id);
    Task UpdateAsync(T entity);
    IQueryable<T> GetAll();
    Task<T> GetAsync(Guid id);
}