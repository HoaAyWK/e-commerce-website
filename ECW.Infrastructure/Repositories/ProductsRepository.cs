using ECW.ApplicationCore.Entities;
using ECW.ApplicationCore.Interfaces;
using ECW.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ECW.Infrastructure.Repositories;

public class ProductsRepository : GenericRepository<Product>, IProductsRepository
{
    public ProductsRepository(ProductContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> GetByIdsAsync(params int[] ids)
    {
        return await dbSet.Where(p => ids.Contains(p.Id))
            .AsNoTracking()
            .ToListAsync();
    }
}