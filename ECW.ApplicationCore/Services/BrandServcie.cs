using AutoMapper;
using ECW.ApplicationCore.DTOs.Brand;
using ECW.ApplicationCore.Entities;
using ECW.ApplicationCore.Interfaces;

namespace ECW.ApplicationCore.Services;

public class BrandService : IBrandService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BrandService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BrandDto>> GetAsync()
    {
        var brands = await _unitOfWork.Brands.AllAsync();
        var brandDtos = _mapper.Map<IEnumerable<Brand>, IEnumerable<BrandDto>>(brands);

        return brandDtos;
    }

    public async Task<BrandDto?> GetByIdAsync(int brandId)
    {
        var brand = await _unitOfWork.Brands.GetByIdAsync(brandId);
        var brandDto = _mapper.Map<BrandDto>(brand);

        return brandDto;
    }

    public async Task<CreateBrandResponse?> CreateAsync(CreateBrandRequest request)
    {
        var brand = new Brand(request.Name);
        var result = await _unitOfWork.Brands.AddAsync(brand);

        if (result is null)
            return null;

        await _unitOfWork.CompleteAsync();
        var response = _mapper.Map<CreateBrandResponse>(result);

        return response;
    }

    public async Task<UpdateBrandResponse?> UpdateAsync(UpdateBrandRequest request)
    {
        var response = new UpdateBrandResponse();
        var existingBrand = await _unitOfWork.Brands.GetByIdAsync(request.Id);

        if (existingBrand is null)
            return null;
        
        existingBrand.Update(request.Name);
        _unitOfWork.Brands.Update(existingBrand);
        await _unitOfWork.CompleteAsync();
        
        var brandDto = _mapper.Map<BrandDto>(existingBrand);
        response.Brand = brandDto;

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