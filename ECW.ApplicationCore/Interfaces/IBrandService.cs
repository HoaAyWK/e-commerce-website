using ECW.ApplicationCore.DTOs.Brand;
using ECW.ApplicationCore.Entities;

namespace ECW.ApplicationCore.Interfaces;

public interface IBrandService
{
    Task<IEnumerable<BrandDto>> GetAsync();
    Task<BrandDto?> GetByIdAsync(int brandId);
    Task<CreateBrandResponse?> CreateAsync(CreateBrandRequest request);
    Task<UpdateBrandResponse?> UpdateAsync(UpdateBrandRequest request);
    Task<DeleteBrandResponse?> DeleteAsync(DeleteBrandRequest request);
}