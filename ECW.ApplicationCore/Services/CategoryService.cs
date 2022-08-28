using AutoMapper;
using ECW.ApplicationCore.DTOs.Category;
using ECW.ApplicationCore.Entities;
using ECW.ApplicationCore.Interfaces;

namespace ECW.ApplicationCore.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDto>> GetAsync()
    {
        var categories = await _unitOfWork.Categories.AllAsync();
        var categoryDtos = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDto>>(categories);

        return categoryDtos;
    }
}