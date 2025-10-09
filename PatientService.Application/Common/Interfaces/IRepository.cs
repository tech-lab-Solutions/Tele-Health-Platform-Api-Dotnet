using System.Linq.Expressions;

namespace PatientService.Application.Common.Interfaces;

public interface IRepository<T> where T : class
{
    public Task<IEnumerable<T>> GetAllAsync();

    public IQueryable<T> GetAll();

    public IQueryable<T> GetAllNoTracking();

    public IQueryable<T> Query();

    public Task<T?> GetByIdAsync(int id);

    public Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    public Task<T?> FindOneAsync(Expression<Func<T, bool>> predicate);

    public Task AddAsync(T entity);

    public void Update(T entity);

    public void Remove(T entity);

    public Task SaveChangesAsync();

    public void RemoveRange(IEnumerable<T> entity);
}

