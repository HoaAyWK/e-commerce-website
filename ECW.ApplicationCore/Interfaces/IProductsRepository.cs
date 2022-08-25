using ECW.ApplicationCore.Entities;

namespace ECW.ApplicationCore.Interfaces;

public interface IProductsRepository : IGenericRepository<Product>
{
    Task<IEnumerable<Product>> GetByIdsAsync(params int[] ids);

    Task<IEnumerable<Product>> ListAsync(int pageSize, int pageIndex, int? brandId, int? categoryId);

    Task<int> CountAsync(int? brandId, int? categoryId);
}