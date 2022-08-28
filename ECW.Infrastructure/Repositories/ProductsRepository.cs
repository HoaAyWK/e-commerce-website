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

    public async Task<IEnumerable<Product>> ListAsync(int pageSize, int pageIndex, int? brandId, int? categoryId)
    {
        if (pageIndex > 0)
            pageIndex = pageIndex - 1;
            
        if (brandId != null && categoryId != null)
        {
            return await dbSet.Where(p => p.BrandId == brandId.Value && p.CategoryId == categoryId.Value)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }
        else if (brandId != null && categoryId == null)
        {
            return await dbSet.Where(p => p.BrandId == brandId.Value)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }
        else if (brandId == null && categoryId != null)
        {
            return await dbSet.Where(p => p.CategoryId == categoryId)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }
        else
        {
            return await dbSet.Skip(pageIndex * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }
    }

    public async Task<int> CountAsync(int? brandId, int? categoryId)
    {
        if (brandId != null && categoryId != null)
        {
            return await dbSet.Where(p => p.BrandId == brandId.Value &&
                p.CategoryId == categoryId)
                .CountAsync();
        }
        else if (brandId != null && categoryId == null)
        {
            return await dbSet.Where(p => p.BrandId == brandId)
                .CountAsync();
        }
        else if (brandId == null && categoryId != null)
        {
            return await dbSet.Where(p => p.CategoryId == categoryId)
                .CountAsync();
        }
        else
        {
            return await dbSet.CountAsync();
        }
    }
}