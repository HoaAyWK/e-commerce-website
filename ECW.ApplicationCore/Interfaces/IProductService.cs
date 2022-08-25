using ECW.ApplicationCore.DTOs.Product;
using ECW.ApplicationCore.Entities;

namespace ECW.ApplicationCore.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductDto>> GetAsync();
    
    Task<ProductDto?> GetByIdAsync(int id);

    Task<CreateProductResponse?> CreateAsync(CreateProductRequest request);

    Task<UpdateProductResposne?> UpdateAsync(UpdateProductRequest request);

    Task<DeleteProductResponse?> DeleteAsync(DeleteProductRequest request);

    Task<int?> CheckIfNotExistAsync(int[] ids);
}