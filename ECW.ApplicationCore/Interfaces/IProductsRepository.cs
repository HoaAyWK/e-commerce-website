using ECW.ApplicationCore.Entities;

namespace ECW.ApplicationCore.Interfaces;

public interface IProductsRepository : IGenericRepository<Product>
{
    Task<IEnumerable<Product>> GetByIdsAsync(params int[] ids);
}