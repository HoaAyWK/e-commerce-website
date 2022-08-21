using System.Linq.Expressions;

namespace ECW.ApplicationCore.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : class
{
    // Get all entities
    Task<IEnumerable<TEntity>> AllAsync();

    // Get entity by Id
    Task<TEntity?> GetByIdAsync(int id);

    Task<bool> AddAsync(TEntity entity);

    Task<bool> UpdateAsync(TEntity entityToUpdate);

    bool Update(TEntity entityToUpdate);

    Task<bool> DeleteAsync(int id);

    void Delete(TEntity entityToDelete);
}