using ECW.ApplicationCore.Interfaces;
using ECW.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ECW.Infrastructure.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected ProductContext context;
    internal DbSet<TEntity> dbSet;

    public GenericRepository(ProductContext context)
    {
        this.context = context;
        this.dbSet = context.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> AllAsync()
    {
        return await dbSet.AsNoTracking().ToListAsync();
    }

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        var result = await dbSet.AddAsync(entity);

        return result.Entity;
    }

    public virtual Task DeleteAsync(TEntity entityToDelete)
    {
        throw new NotImplementedException();
    }

    public virtual void Delete(TEntity entityToDelete)
    {
        if (context.Entry(entityToDelete).State == EntityState.Detached)
        {
            dbSet.Attach(entityToDelete);
        }

        dbSet.Remove(entityToDelete);
    }

    public virtual Task UpdateAsync(TEntity entityToUpdate)
    {
        throw new NotImplementedException();
    }

    public virtual void Update(TEntity entityToUpdate)
    {
        dbSet.Attach(entityToUpdate);
        context.Entry(entityToUpdate).State = EntityState.Modified;
    }

    public virtual async Task<TEntity?> GetByIdAsync(int id)
    {
        return await dbSet.FindAsync(id);
    }
}