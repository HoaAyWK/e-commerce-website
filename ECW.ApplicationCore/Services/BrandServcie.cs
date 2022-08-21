using ECW.ApplicationCore.DTOs.Brand;
using ECW.ApplicationCore.Entities;
using ECW.ApplicationCore.Interfaces;

namespace ECW.ApplicationCore.Services;

public class BrandService : IBrandService
{
    private readonly IUnitOfWork _unitOfWork;

    public BrandService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Brand>> GetAsync()
    {
        return await _unitOfWork.Brands.AllAsync();
    }

    public async Task<Brand?> GetByIdAsync(int brandId)
    {
        return await _unitOfWork.Brands.GetByIdAsync(brandId);
    }

    public async Task<Brand> CreateAsync(CreateBrandRequest request)
    {
        var brand = new Brand(request.Name);
        var result = await _unitOfWork.Brands.AddAsync(brand);
        await _unitOfWork.CompleteAsync();

        return result;
    }

    public async Task<UpdateBrandResponse?> UpdateAsync(Brand brandToUpdate)
    {
        var response = new UpdateBrandResponse();
        var existingBrand = await _unitOfWork.Brands.GetByIdAsync(brandToUpdate.Id);

        if (existingBrand is null)
            return null;
        
        existingBrand.Update(brandToUpdate.Name);

        _unitOfWork.Brands.Update(existingBrand);
        await _unitOfWork.CompleteAsync();
        
        return response;
    }

    public async Task<DeleteBrandResponse?> DeleteAsync(DeleteBrandRequest request)
    {
        var response = new DeleteBrandResponse();
        var brandToDelete = await _unitOfWork.Brands.GetByIdAsync(request.BrandId);

        if (brandToDelete is null)
            return null;

        _unitOfWork.Brands.Delete(brandToDelete);
        await _unitOfWork.CompleteAsync();
        
        return response;
    }
}