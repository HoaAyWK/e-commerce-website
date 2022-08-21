using System.Linq.Expressions;

namespace ECW.ApplicationCore.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : class
{
    // Get all entities
    Task<IEnumerable<TEntity>> AllAsync();

    // Get entity by Id
    Task<TEntity?> GetByIdAsync(int id);

    Task<TEntity> AddAsync(TEntity entity);

    Task UpdateAsync(TEntity entityToUpdate);

    void Update(TEntity entityToUpdate);

    Task DeleteAsync(TEntity entityToDelete);

    void Delete(TEntity entityToDelete);
}