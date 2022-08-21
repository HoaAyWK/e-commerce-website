using ECW.ApplicationCore.DTOs.Brand;
using ECW.ApplicationCore.Entities;

namespace ECW.ApplicationCore.Interfaces;

public interface IBrandService
{
    Task<IEnumerable<Brand>> GetAsync();
    Task<Brand?> GetByIdAsync(int brandId);
    Task<Brand> CreateAsync(CreateBrandRequest request);
    Task<UpdateBrandResponse?> UpdateAsync(Brand brandToUpdate);
    Task<DeleteBrandResponse?> DeleteAsync(DeleteBrandRequest request);
}