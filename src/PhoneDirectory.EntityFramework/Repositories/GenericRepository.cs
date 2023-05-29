using Microsoft.EntityFrameworkCore;
using PhoneDirectory.Shared.Entities;
using PhoneDirectory.Shared.Repositories;

namespace PhoneDirectory.EntityFramework.Repositories;

public class GenericRepository<T> : IRepository<T> where T : EntityBase
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task CreateAsync(T entity)
    {
        _dbSet.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetAsync(id);
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public IQueryable<T> GetAll()
    {
        return _dbSet.Where(i => i.IsDeleted == false).AsQueryable();
    }

    public async Task<T> GetAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity!;
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    private bool _disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}