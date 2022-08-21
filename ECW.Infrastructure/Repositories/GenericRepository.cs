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

    public virtual async Task<bool> AddAsync(TEntity entity)
    {
        await dbSet.AddAsync(entity);
        
        return true;
    }

    public virtual async Task<bool> DeleteAsync(int id)
    {
        TEntity entityToDelete = await dbSet.FindAsync(id);

        if (entityToDelete == null)
            return false;
    
        Delete(entityToDelete);

        return true;
    }

    public virtual void Delete(TEntity entityToDelete)
    {
        if (context.Entry(entityToDelete).State == EntityState.Detached)
        {
            dbSet.Attach(entityToDelete);
        }

        dbSet.Remove(entityToDelete);
    }

    public virtual Task<bool> UpdateAsync(TEntity entityToUpdate)
    {
        throw new NotImplementedException();
    }

    public virtual bool Update(TEntity entityToUpdate)
    {
        dbSet.Attach(entityToUpdate);
        context.Entry(entityToUpdate).State = EntityState.Modified;
        return true;
    }

    public virtual async Task<TEntity?> GetByIdAsync(int id)
    {
        return await dbSet.FindAsync(id);
    }
}